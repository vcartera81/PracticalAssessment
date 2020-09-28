using Microsoft.EntityFrameworkCore;
using PracticalAssessment.DataAccessContract.Entities;
using PracticalAssessment.SqlDataAccess.Mappings;

namespace PracticalAssessment.SqlDataAccess
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> context) : base(context)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TransactionMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CurrencyMap());
            modelBuilder.ApplyConfiguration(new RecipientMap());
        }
    }
}
