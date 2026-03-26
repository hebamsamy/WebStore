using EcommerceDB.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceDB.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(t => t.Id);
            builder.HasOne(i => i.User)
                .WithOne(i => i.Client)
                .HasForeignKey<Client>(i => i.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
