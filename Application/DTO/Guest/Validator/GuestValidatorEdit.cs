using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.Guest.Validator
{
  public class GuestValidatorEdit : AbstractValidator<GuestDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public GuestValidatorEdit()
    {
      RuleFor(x => x.FirstName).NotEmpty().WithMessage(AppMessage.ValidatorGuestNameMessage);
      RuleFor(x => x.LastName).NotEmpty().WithMessage(AppMessage.ValidatorGuestLastNameMessage);
      RuleFor(x => x.BookingId).NotEmpty().WithMessage(AppMessage.ValidatorGuestBookingIdMessage);
    }
  }
}
