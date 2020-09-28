using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracticalAssessment.DataAccessContract.Entities;

namespace PracticalAssessment.SqlDataAccess.Mappings
{
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction");
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.OccuredOn).IsRequired();
            builder.Property(_ => _.Title).HasMaxLength(250).IsRequired();
            builder.Property(_ => _.Amount).IsRequired();

            builder.Property(_ => _.CurrencyId);
            builder.Property(_ => _.CategoryId);
            builder.Property(_ => _.RecipientId);

            builder.HasOne(_ => _.Currency)
                .WithMany()
                .HasForeignKey(_ => _.CurrencyId);

            builder.HasOne(_ => _.Recipient)
                .WithMany()
                .HasForeignKey(_ => _.RecipientId);

            builder.HasOne(_ => _.Category)
                .WithMany()
                .HasForeignKey(_ => _.CategoryId);
        }
    }
}
