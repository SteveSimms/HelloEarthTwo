using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEarthTwo.Models
{
    class EFContext : DbContext
    {
        //private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=EFCore;Trusted_Connection=True;"; //May have to c hange localbd to localhost
        private const string connectionString = "Server=localhost; Port=5432; Database=HelloEarth2Project;Username= postgres; Password=M@l1k19"; //May have to c hange localbd to localhost

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseNpgsql(connectionString);

        }
        public DbSet<Hero> Heroes { get; set; }

        public DbSet<AntiHero> AntiHeroes { get; set; }

        public DbSet<Villain> Villains { get; set; }
    }
}
