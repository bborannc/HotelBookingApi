namespace HotelBookingApi.Core.Dtos
{
    public class RoomDto
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public string RoomType { get; set; } = string.Empty;
        public decimal DailyPrice { get; set; }
        public int Capacity { get; set; }
    }
}
