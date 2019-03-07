using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloCore.Areas.Identity.Data;
using HelloCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HelloCore.Data
{
    public class HelloCoreContext : IdentityDbContext<CustomUser>
    {
        public HelloCoreContext (DbContextOptions<HelloCoreContext> options)
            : base(options)
        {
        }

        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Bestelling> Bestellingen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Klant>().ToTable("Klant");
            modelBuilder.Entity<Bestelling>().ToTable("Bestelling").Property(p=>p.Prijs).HasColumnType("decimal(18,2)");
        }
    }
}
