using RITest.Entities;
using Microsoft.EntityFrameworkCore;

namespace RITest.Database
{
    public class DataContext: DbContext
    {  
        public DbSet<DrillBlockEntity> DrillBlock { get; set; }
        public DbSet<DrillBlockPointEntity> DrillBlockPoint { get; set; }
        public DbSet<HoleEntity> Hole { get; set; }
        public DbSet<HolePointEntity> HolePoint { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }
    }
}
