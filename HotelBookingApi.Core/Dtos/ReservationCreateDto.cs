namespace HotelBookingApi.Core.Dtos
{
    public class ReservationCreateDto
    {
        public int RoomId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
