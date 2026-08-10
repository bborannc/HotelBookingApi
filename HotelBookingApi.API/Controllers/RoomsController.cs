using HotelBookingApi.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.API.Controllers
{
    public class RoomsController : CustomBaseController
    {
        private readonly RoomService _roomService;

        public RoomsController(RoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: api/rooms/available?hotelId=1&checkIn=2026-09-01&checkOut=2026-09-05
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableRooms([FromQuery] int hotelId, [FromQuery] DateTime checkIn, [FromQuery] DateTime checkOut)
        {
            var result = await _roomService.GetAvailableRoomsAsync(hotelId, checkIn, checkOut);
            return CreateActionResult(result);
        }
    }
}
