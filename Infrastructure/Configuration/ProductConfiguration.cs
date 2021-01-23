
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
            builder.Property(p=>p.Description).IsRequired().HasMaxLength(500);
            builder.Property(p=>p.UPC).IsRequired().HasMaxLength(12);
            builder.Property(p=>p.NetWeight).IsRequired().HasMaxLength(20);
            builder.Property(p=>p.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p=>p.SalePrice).HasColumnType("decimal(18,2)");
            builder.Property(p=>p.PictureUrl).IsRequired();

            builder.HasOne(b=>b.ProductBrand).WithMany()
                .HasForeignKey(p=>p.ProductBrandId);
                
            builder.HasOne(b => b.ProductType).WithMany()
                .HasForeignKey(b => b.ProductTypeId);            
        }
    }
}