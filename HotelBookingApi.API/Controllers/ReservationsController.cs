using HotelBookingApi.Core.Dtos;
using HotelBookingApi.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.API.Controllers
{
    public class ReservationsController : CustomBaseController
    {
        private readonly ReservationService _reservationService;

        public ReservationsController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // POST: api/reservations
        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] ReservationCreateDto dto)
        {
            var result = await _reservationService.CreateReservationAsync(dto);
            return CreateActionResult(result);
        }

        // DELETE: api/reservations/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelReservation(int id)
        {
            var result = await _reservationService.CancelReservationAsync(id);
            return CreateActionResult(result);
        }
    }
}