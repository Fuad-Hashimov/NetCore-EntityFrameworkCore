using EntityFrameworkCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Concrete.EntityFrameworkCore.ContextAplication
{
    public class AplicationContext : DbContext
    {

        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .UseSqlServer("Data Source = DESKTOP-A6PH9IP; Initial Catalog = AplicationDb;Integrated Security = True;");

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Catgories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product_Catogory> Product_Catogories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product_Catogory>()
                .HasKey(I => new 
                {
                    I.ProductId,I.CategoryId
                });
            modelBuilder.Entity<Product_Catogory>()
                .HasOne(I => I.Product)
                .WithMany(p => p.Product_Catogories)
                .HasForeignKey(I => I.ProductId);

            modelBuilder.Entity<Product_Catogory>()
                .HasOne(c => c.Category)
                .WithMany(pc => pc.Product_Catogories)
                .HasForeignKey(c => c.CategoryId);

            //modelBuilder.Entity<Product_Catogory>()
            //    .ToTable("ProductsCategories");

            modelBuilder.Entity<Customer>()
                .Property(c => c.IdentityNumber)
                    .IsRequired()
                    .HasMaxLength(11);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Name).IsUnique();
                
        }
    }
}
