using Application.DTO.Guest.Validator;
using FluentValidation;

namespace Application.DTO.Guest.ClientRequest
{
  public class AddGuestRequestValidator : AbstractValidator<AddGuestRequest>
  {
    public AddGuestRequestValidator()
    {
      // Определяет HotelValidator в качестве валидатора свойства Hotel.
      // Позволяет повторно использовать созданные ранее правила валидации
      RuleFor(p => p.Guest).SetValidator(new GuestValidatorCreate());
    }
  }
}
