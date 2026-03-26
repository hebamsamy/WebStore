using EcommerceDB.Configuration;
using EcommerceDB.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceDB.Context
{
    public class EcommerceDBContext :IdentityDbContext<User>
    {
        public EcommerceDBContext(DbContextOptions options):base(options) { }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ProductAttachment> ProductAttachments { get; set; }

        public override int SaveChanges()
        {


            //Console.WriteLine("Called");

            var data = base.ChangeTracker.Entries();


            return base.SaveChanges();
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=.;Initial Catalog=ECommerceDB;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ShopConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new ProviderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());


            modelBuilder.Entity<Category>().HasData(
                new Category { ID= 1, Name = "Food", Description = "Food" },
                new Category { ID = 2, Name = "Cloth", Description = "Cloth" },
                new Category { ID = 3, Name = "Electroics", Description = "Electroics" }
                );

            

            base.OnModelCreating(modelBuilder);
        }

    }
}
