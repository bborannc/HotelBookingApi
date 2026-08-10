using HotelBookingApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBookingApi.Data.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CustomerName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.TotalPrice).HasPrecision(18, 2);

            // One-to-Many İlişki: Bir Odanın birden fazla Rezervasyonu olur
            builder.HasOne(x => x.Room)
                   .WithMany(x => x.Reservations)
                   .HasForeignKey(x => x.RoomId);
        }
    }
}
