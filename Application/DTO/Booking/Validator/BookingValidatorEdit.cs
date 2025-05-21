using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.Booking.Validator
{
  public class BookingValidatorEdit : AbstractValidator<BookingDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public BookingValidatorEdit()
    {
      RuleFor(x => x.Name).NotEmpty().WithMessage(AppMessage.ValidatorBookingNameMessage);
      RuleFor(x => x.ArrivalDate).NotEmpty().WithMessage(AppMessage.ValidatorBookingArrivalDateMessage);
      RuleFor(x => x.DepartureDate).NotEmpty().WithMessage(AppMessage.ValidatorBookingDepartureDateMessage);
    }
  }
}
