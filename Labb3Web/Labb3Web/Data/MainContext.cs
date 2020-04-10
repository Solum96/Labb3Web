using Labb3Web.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3Web.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Viewing> Viewings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movies");
            modelBuilder.Entity<Salon>().ToTable("Salons");
            modelBuilder.Entity<Ticket>().ToTable("Tickets");
            modelBuilder.Entity<Viewing>().ToTable("Viewings");
        }
    }
}
