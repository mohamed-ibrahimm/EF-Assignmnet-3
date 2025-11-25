using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EF_Assignment_3.Models 
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=CompanyDb;Trusted_Connection=True;TrustServerCertificate=True;");

        }

        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Airline — Phones (1:M)
            modelBuilder.Entity<Phone>()
                .HasOne(p => p.Airline)
                .WithMany(a => a.Phones)
                .HasForeignKey(p => p.AirlineId);

            // Airline — Employees (1:M)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Airline)
                .WithMany(a => a.Employees)
                .HasForeignKey(e => e.AirlineId);

            // Airline — Aircrafts (1:M)
            modelBuilder.Entity<Aircraft>()
                .HasOne(a => a.Airline)
                .WithMany(l => l.Aircrafts)
                .HasForeignKey(a => a.AirlineId);

            // Airline — Transactions (1:M)
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Airline)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AirlineId);

            // Aircraft — Assignment (1:M)
            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Aircraft)
                .WithMany(ac => ac.Assignments)
                .HasForeignKey(a => a.AircraftId);

            // Route — Assignment (1:M)
            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Route)
                .WithMany(r => r.Assignments)
                .HasForeignKey(a => a.RouteId);
        }
    }
}
