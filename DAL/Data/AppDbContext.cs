using DAL.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> option): base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameDevice>().HasKey(e => new { e.GameId, e.DeviceId }); 
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<GameDevice> GameDevice { get; set; }

        public DbSet<Device> Device { get; set; }

        public DbSet<Game> Game { get;set;}
        public DbSet<Category> Category { get; set;}   
    }
}
