using HotelBookingApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBookingApi.Data.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RoomNumber).IsRequired().HasMaxLength(20);
            builder.Property(x => x.RoomType).IsRequired().HasMaxLength(50);
            builder.Property(x => x.DailyPrice).HasPrecision(18, 2);

            // One-to-Many İlişki: Bir Otelin birden fazla Odası olur
            builder.HasOne(x => x.Hotel)
                   .WithMany(x => x.Rooms)
                   .HasForeignKey(x => x.HotelId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
    new Room { Id = 1, HotelId = 1, RoomNumber = "101", RoomType = "Single", DailyPrice = 1000, Capacity = 1 },
    new Room { Id = 2, HotelId = 1, RoomNumber = "102", RoomType = "Double", DailyPrice = 1800, Capacity = 2 },
    new Room { Id = 3, HotelId = 1, RoomNumber = "201", RoomType = "Suite", DailyPrice = 3500, Capacity = 4 }
);
        }
    }
}
