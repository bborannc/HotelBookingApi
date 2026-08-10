using AutoMapper;
using HotelBookingApi.Core.Dtos;
using HotelBookingApi.Core.Entities;
using HotelBookingApi.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Service.Services
{
    public class ReservationService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ReservationService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<ReservationDto>> CreateReservationAsync(ReservationCreateDto dto)
        {
            var room = await _context.Rooms.FindAsync(dto.RoomId);
            if (room == null)
            {
                return CustomResponseDto<ReservationDto>.Fail(404, "Seçilen oda bulunamadı.");
            }

            // Seçilen oda tarihler arasında müsait mi kontrolü
            bool isOccupied = await _context.Reservations.AnyAsync(res =>
                res.RoomId == dto.RoomId &&
                res.CheckInDate < dto.CheckOutDate &&
                res.CheckOutDate > dto.CheckInDate
            );

            if (isOccupied)
            {
                return CustomResponseDto<ReservationDto>.Fail(400, "Seçilen oda belirtilen tarihler arasında dolu.");
            }

            // Toplam Fiyat Hesaplama (Gün Sayısı * Günlük Ücret)
            int totalDays = (dto.CheckOutDate.Date - dto.CheckInDate.Date).Days;
            decimal totalPrice = totalDays * room.DailyPrice;

            var reservation = _mapper.Map<Reservation>(dto);
            reservation.TotalPrice = totalPrice;

            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();

            var responseDto = _mapper.Map<ReservationDto>(reservation);
            return CustomResponseDto<ReservationDto>.Success(201, responseDto);
        }
    }
}
