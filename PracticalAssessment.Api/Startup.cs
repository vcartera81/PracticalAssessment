using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PracticalAssessment.Api.Middlewares;
using PracticalAssessment.Business;
using PracticalAssessment.SqlDataAccess;

namespace PracticalAssessment.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:4200", "https://practicalassessment.vcartera.info")
                    .SetPreflightMaxAge(TimeSpan.FromMinutes(10));
            }));

            services.AddControllers();

            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("AppConnectionString")));
            services.AddSwaggerGen();
            services.AddAutoMapper(_ =>
            {
                _.AddProfile<BusinessAutoMapperProfile>();
                //_.AddProfile();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new SqlDataAccess.RepositoryModule());
            builder.RegisterModule(new Business.BusinessModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseSwagger();
            app.UseSwaggerUI(_ => _.SwaggerEndpoint("/swagger/v1/swagger.json", "Spendings API v1.0"));

            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
