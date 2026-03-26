using EcommerceDB.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace EcommerceDB.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Create Table Sales.Product( id int pK, )
            builder.ToTable("Product","Sales");
            builder.HasKey(p => p.ID);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Price).IsRequired().HasColumnType("money").HasDefaultValue(10);



            // Relationships

            //Product Belonge to Provider (Many-to-One)
            builder.HasOne(p => p.Provider)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.ProviderID)
                .OnDelete(DeleteBehavior.Cascade);


            //Product under Category (Many-to-One)
            builder.HasOne(p => p.Category)
                .WithMany(c=>c.Products)
                .HasForeignKey(p=>p.CategoryID)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Property(p => p.Stock)
                .IsRequired(false).HasDefaultValue(1);

            builder.Property(p => p.ISDeleted)
               .IsRequired(false).HasDefaultValue(false);

            builder.HasMany(p => p.Attachments)
                .WithOne(a => a.Product)
                .HasForeignKey(a => a.ProductId)
                .OnDelete(DeleteBehavior.Cascade);


            ////
            ///
            builder
                .HasQueryFilter(p => p.Stock > 0 && p.ISDeleted == false);
        }
    }
}
