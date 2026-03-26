using EcommerceDB.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceDB.Configuration
{
    public class OrderItemConfiguration :IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");
            builder.HasKey(oi => new { oi.OrderID, oi.ProductID });



            builder.HasOne(o => o.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(o => o.OrderID);

            builder.HasOne(o => o.Product)
                .WithMany(p => p.Items)
                .HasForeignKey(o => o.ProductID);
        }
   
    }
}
