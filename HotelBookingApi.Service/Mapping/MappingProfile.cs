using AutoMapper;
using HotelBookingApi.Core.Dtos;
using HotelBookingApi.Core.Entities;

namespace HotelBookingApi.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<ReservationCreateDto, Reservation>();
        }
    }
}
