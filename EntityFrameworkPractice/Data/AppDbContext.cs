using EntityFrameworkPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkPractice.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Setting>Settings {get; set;} 
        public DbSet<Country>Countries {get; set;}    

        public DbSet<City> Cities { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-9DDEKNH\\SQLEXPRESS;Database=EntityFrameworkPB101Db;Trusted_Connection=true");
        }
    }
}
