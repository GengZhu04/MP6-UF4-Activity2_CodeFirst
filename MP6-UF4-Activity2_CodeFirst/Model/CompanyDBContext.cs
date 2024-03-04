using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MP6_UF4_Activity2_CodeFirst.Model
{
    public class CompanyDBContext : DbContext
    {
        public CompanyDBContext() { }
        public CompanyDBContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=COMPANYGZOP;Uid=root;Pwd=\"\"");
            }
        }


        public virtual DbSet<Offices> Offices { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<ProductLines> ProductLines { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Employees N - 1 Offices
            modelBuilder.Entity<Employees>()
                .HasOne(e => e.Office)
                .WithMany(o => o.Employees)
                .HasForeignKey(e => e.OfficeCode);
            // Customers N - 1 Employees
            modelBuilder.Entity<Customers>()
                .HasOne(c => c.Employee)
                .WithMany(e => e.Customers)
                .HasForeignKey(c => c.SalesRepEmployeeNumber);
            // Per Tenir Dos Claus Primaries
            modelBuilder.Entity<Payments>()
                .HasKey(payments => new { payments.CustomerNumber, payments.CheckNumber });
            // Payments N - 1 Customers
            modelBuilder.Entity<Payments>()
                .HasOne(p => p.Customer)
                .WithMany(c => c.Payments)
                .HasForeignKey(p => p.CustomerNumber);
            // Orders N - 1 Customers
            modelBuilder.Entity<Orders>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerNumberId);
            // Taula Creada A Partir del Relació Products N - M Orders
            modelBuilder.Entity<OrderDetails>()
                .HasKey(o => new { o.ProductCode, o.OrderNumber });
            modelBuilder.Entity<OrderDetails>()
                .HasOne(oD => oD.Orders)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(oD => oD.OrderNumber);
            modelBuilder.Entity<OrderDetails>()
                .HasOne(oD => oD.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(oD => oD.ProductCode);
            // Product N - 1 ProductLines
            modelBuilder.Entity<Products>()
                .HasOne(p => p.ProductLine)
                .WithMany(pl => pl.Products)
                .HasForeignKey(p => p.ProductLineId);
        }
    }
}
