using Microsoft.EntityFrameworkCore;
namespace CloudWeather.Temparature.DataAccess
{
    public class TempDbContext:DbContext
    {
        public TempDbContext()
        {

        }
        public TempDbContext(DbContextOptions opts) : base(opts) 
        {

        }
        public DbSet<Temparature> Temparature { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SnakeCaseIdentityTableNames(modelBuilder);
        }

        private void SnakeCaseIdentityTableNames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Temparature>(b => {b.ToTable("temparature"); });
        }
    }
}
