using EcommerceDB.Entites;
using EcommerceDB.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceDB.Configuration
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.OrderStatus)
                .HasConversion<string>()
                .HasDefaultValue(OrderStatus.Pending);

            builder.Property(o => o.DateTime)
               .HasDefaultValueSql("GETDATE()");
            //.HasDefaultValue(DateTime.Now);

            builder.HasOne(i => i.Client)
                .WithMany(i => i.Orders)
                .HasForeignKey(o => o.ClientId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
