using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PracticalAssessment.Business.Exception;

namespace PracticalAssessment.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (BusinessException ex)
            {
                context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}
