using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRA.EF
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

        public DbSet<Horse> Horses { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceCard> RaceCards { get; set; }
    }
}
