using HotelBookingApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBookingApi.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.City).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Address).HasMaxLength(250);

            builder.HasData(
                    new Hotel { Id = 1, Name = "Grand Istanbul Hotel", City = "İstanbul", Address = "Taksim Meydanı No:1" },
                    new Hotel { Id = 2, Name = "Ege Palas", City = "İzmir", Address = "Alsancak No:45" }
                );
        }

    }
}
