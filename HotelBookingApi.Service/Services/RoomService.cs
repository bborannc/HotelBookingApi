using AutoMapper;
using HotelBookingApi.Core.Dtos;
using HotelBookingApi.Core.Entities;
using HotelBookingApi.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Service.Services
{
    public class RoomService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RoomService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // İki tarih arası boş oda sorgulama (Async/Await & IQueryable)
        public async Task<CustomResponseDto<List<RoomDto>>> GetAvailableRoomsAsync(int hotelId, DateTime checkIn, DateTime checkOut)
        {
            if (checkIn >= checkOut)
            {
                return CustomResponseDto<List<RoomDto>>.Fail(400, "Giriş tarihi çıkış tarihinden önce olmalıdır.");
            }

            // 1. IQueryable başlatılıyor (Sorgu henüz SQL'e gitmedi)
            IQueryable<Room> roomsQuery = _context.Rooms.AsNoTracking().Where(r => r.HotelId == hotelId);

            // 2. İki tarih arasında çakışan rezervasyonu OLMAYAN odalar SQL seviyesinde filtreleniyor
            roomsQuery = roomsQuery.Where(room => !room.Reservations.Any(res =>
                res.CheckInDate < checkOut && res.CheckOutDate > checkIn
            ));

            // 3. ToListAsync() ile sorgu veritabanında çalıştırılıyor
            var availableRooms = await roomsQuery.ToListAsync();

            var roomDtos = _mapper.Map<List<RoomDto>>(availableRooms);
            return CustomResponseDto<List<RoomDto>>.Success(200, roomDtos);
        }
    }
}
