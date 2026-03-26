using EcommerceDB.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceDB.Configuration
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.ToTable("Provider");
            builder.HasKey(p => p.ID);
            builder.HasIndex(p=>p.NationalID).IsUnique();

            builder.HasOne(i => i.User)
               .WithOne(i => i.Provider)
               .HasForeignKey<Provider>(i => i.UserId)
               .OnDelete(DeleteBehavior.NoAction);

            //builder.HasNoKey();
            //builder.HasIndex(p=>p.UserName).IsClustered(true);

        }
    }
}
