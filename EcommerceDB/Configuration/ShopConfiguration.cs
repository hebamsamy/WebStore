using EcommerceDB.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceDB.Configuration
{
    public class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.ToTable("Shop");
            builder.HasKey(s => s.ID);


            builder.HasOne(s => s.Provider)
                .WithOne(p => p.Shop)
                .HasForeignKey<Shop>(s => s.ProviderID);

            //builder.ComplexProperty(s => s.Address);
            builder.OwnsMany(s => s.Addresses);
        }
    }
}
