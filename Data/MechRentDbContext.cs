using System;
using Microsoft.EntityFrameworkCore;
using MechRentAPI.Models;

namespace MechRentAPI.Data
{
    public class MechRentDbContext : DbContext
    {
        public MechRentDbContext(DbContextOptions<MechRentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Excavator> Excavators { get; set; }
        public DbSet<PublicWork> PublicWorks { get; set; }
        public DbSet<RentedExcavator> RentedExcavators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuraciones adicionales si son necesarias
        }
    }
}

