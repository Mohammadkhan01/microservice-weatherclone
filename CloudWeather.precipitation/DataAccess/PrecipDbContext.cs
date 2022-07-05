using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudWeather.precipitation.DataAccess
{
    public class PrecipDbContext:DbContext
    {
        public PrecipDbContext()
        {

        }
        public PrecipDbContext(DbContextOptions opts) : base(opts) 
        {

        }
        public DbSet<Precipitation> Precipitations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SnakeCaseIdentityTableNames(modelBuilder);
        }

        private void SnakeCaseIdentityTableNames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Precipitation>(b => {b.ToTable("precipitation"); });
        }
    }
}
