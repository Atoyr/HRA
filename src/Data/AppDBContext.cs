using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRA.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
          builder.Entity<RaceResult>().HasKey(table => new {
              table.RaceID, table.HorseName
              });

          builder.Entity<Time>().HasKey(table => new {
              table.RaceID, table.HorseName, table.Range
              });
        }

        public DbSet<Horse> Horses { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceCard> RaceCards { get; set; }
        public DbSet<RaceResultSummary> RaceResultSummaries { get; set; }
        public DbSet<RaceResult> RaceResults { get; set; }
        public DbSet<Time> Times { get; set; }
    }
}
