using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracticalAssessment.DataAccessContract.Entities;

namespace PracticalAssessment.SqlDataAccess.Mappings
{
    public class CurrencyMap : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Name).HasMaxLength(250);
            builder.Property(_ => _.Code).HasMaxLength(3);
            builder.Property(_ => _.Symbol).HasMaxLength(2);
        }
    }
}
