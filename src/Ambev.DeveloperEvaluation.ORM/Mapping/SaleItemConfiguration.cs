using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Product).IsRequired().HasMaxLength(100);
            builder.Property(s => s.UnitPrice).HasColumnType("decimal(18,2)");
            builder.Property(s => s.Discount).HasColumnType("decimal(18,2)");
            builder.Property(s => s.Total).HasColumnType("decimal(18,2)");
        }
    }
}
