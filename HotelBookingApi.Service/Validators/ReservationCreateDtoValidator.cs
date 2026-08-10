using FluentValidation;
using HotelBookingApi.Core.Dtos;

namespace HotelBookingApi.Service.Validators
{
    public class ReservationCreateDtoValidator : AbstractValidator<ReservationCreateDto>
    {
        public ReservationCreateDtoValidator()
        {
            RuleFor(x => x.RoomId).GreaterThan(0).WithMessage("Geçerli bir oda seçilmelidir.");
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Müşteri adı boş bırakılamaz.");
            RuleFor(x => x.CheckInDate).GreaterThanOrEqualTo(DateTime.UtcNow.Date)
                .WithMessage("Giriş tarihi bugünden önce olamaz.");
            RuleFor(x => x.CheckOutDate).GreaterThan(x => x.CheckInDate)
                .WithMessage("Çıkış tarihi, giriş tarihinden sonra olmalıdır.");
        }
    }
}
