using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.Guest.Validator
{
  public class GuestValidatorCreate : AbstractValidator<GuestCreateDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public GuestValidatorCreate()
    {
      RuleFor(x => x.FirstName).NotEmpty().WithMessage(AppMessage.ValidatorGuestNameMessage);
      RuleFor(x => x.LastName).NotEmpty().WithMessage(AppMessage.ValidatorGuestLastNameMessage);
      RuleFor(x => x.BookingId).NotEmpty().WithMessage(AppMessage.ValidatorGuestBookingIdMessage);
    }
  }
}
