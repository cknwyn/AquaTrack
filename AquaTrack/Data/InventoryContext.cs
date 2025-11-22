using AquaTrack.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaTrack.Data
{
    internal class InventoryContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TaskNotes> TaskNotes { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<Damaged> DamagedItems { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<TaskNotes>()
                .HasIndex(t => t.NoteId)
                .IsUnique();

            modelBuilder.Entity<Products>()
                .HasMany(p => p.SaleItems)
                .WithOne(si => si.Product)
                .HasForeignKey(si => si.ProductID);

            modelBuilder.Entity<Products>()
                // damage items, sale items, and suppliers
                .HasMany(p => p.DamageAndCasualties)
                .WithOne(d => d.Product)
                .HasForeignKey(d => d.ProductID);

            modelBuilder.Entity<Products>()
                // supplier relationship
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierID);

            modelBuilder.Entity<Products>()
                // sale items relationship
                .HasMany(p => p.SaleItems)
                .WithOne(si => si.Product)
                .HasForeignKey(si => si.ProductID);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Sales)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.CustomerID);

            modelBuilder.Entity<Sale>()
                .HasMany(s => s.SaleItems)
                .WithOne(i => i.Sale)
                .HasForeignKey(i => i.SaleID);
        }
    }
}
