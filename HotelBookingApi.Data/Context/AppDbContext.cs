using System.Reflection;
using HotelBookingApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Global Query Filters (Silinmiş verileri varsayılan olarak sorgulardan ele)
            modelBuilder.Entity<Hotel>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Room>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Reservation>().HasQueryFilter(x => !x.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }

        // Soft Delete Interceptor / Override
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Deleted)
                {
                    // Fiziksel silmeyi iptal et, güncellemeye çevir ve IsDeleted flag'ini işaretle
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}