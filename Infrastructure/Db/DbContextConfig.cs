using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using vehicle_enrollment_api.Entities;

namespace vehicle_enrollment.Db
{
    public class DbContextConfig : DbContext
    {
        private readonly IConfiguration _configurationAppSettings;
        public DbContextConfig(IConfiguration configurationAppSettings)
        {
            _configurationAppSettings = configurationAppSettings;
        }
        public DbSet<Admin> Admins { get; set; } = default!;
        public DbSet<Vehicle> Vehicle { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(

                new Admin {
                    Id = 1,
                    Email = "admin@teste.com",
                    Password = "12345",
                    Profile = "Admin"
                }
            );
            
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configurationAppSettings.GetConnectionString("mysql")?.ToString();
                if (!string.IsNullOrEmpty(connectionString))
                {
                    optionsBuilder.UseMySql(
                        connectionString,
                        ServerVersion.AutoDetect(connectionString));
                }
            }
        }
    }
}