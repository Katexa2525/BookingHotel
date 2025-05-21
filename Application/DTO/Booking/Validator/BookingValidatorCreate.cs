using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.Booking.Validator
{
  public class BookingValidatorCreate : AbstractValidator<BookingCreateDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public BookingValidatorCreate()
    {
      RuleFor(x => x.Name).NotEmpty().WithMessage(AppMessage.ValidatorBookingNameMessage);
      RuleFor(x => x.ArrivalDate).NotEmpty().WithMessage(AppMessage.ValidatorBookingArrivalDateMessage);
      RuleFor(x => x.DepartureDate).NotEmpty().WithMessage(AppMessage.ValidatorBookingDepartureDateMessage);
    }
  }
}
