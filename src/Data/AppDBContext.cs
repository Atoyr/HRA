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

        public DbSet<Horse> Horses { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceResultSummary> RaceResultSummaries { get; set; }
        public DbSet<RaceResult> RaceResults { get; set; }
        public DbSet<Time> Times { get; set; }
    }
}
