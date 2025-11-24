using AquaTrack.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaTrack.Data
{
    public class InventoryContext : DbContext
    {

        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskNotes> TaskNotes { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Fish> Fish { get; set; }
        public DbSet<Equipment> Equipment { get; set; } 
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<Damaged> DamagedItems { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Products>().ToTable("Products");
            modelBuilder.Entity<Fish>().ToTable("Fish");
            modelBuilder.Entity<Equipment>().ToTable("Equipment");

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserID)
                .IsUnique();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    Username = "admin",
                    Password = "admin123",
                    Email = "test@gmail.com",
                    Role = "Admin"
                } );

            modelBuilder.Entity<Supplier>()
                .HasIndex(s => s.SupplierID)
                .IsUnique();

            modelBuilder.Entity<TaskNotes>()
                .HasIndex(t => t.TasknotesID)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.CustomerID)
                .IsUnique();
        }
    }
}
