using Microsoft.EntityFrameworkCore;
namespace CloudWeather.Report.DataAccess
{
    public class WeatherReportDbContext:DbContext
    {
        public WeatherReportDbContext()
        {

        }
        public WeatherReportDbContext(DbContextOptions opts) : base(opts) 
        {

        }
        public DbSet<WeatherReport> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SnakeCaseIdentityTableNames(modelBuilder);
        }

        private void SnakeCaseIdentityTableNames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherReport>(b => {b.ToTable("report"); });
        }
    }
}
