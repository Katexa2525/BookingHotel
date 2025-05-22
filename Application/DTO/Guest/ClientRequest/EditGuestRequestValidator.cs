using Application.DTO.Guest.Validator;
using FluentValidation;

namespace Application.DTO.Guest.ClientRequest
{
  public class EditGuestRequestValidator : AbstractValidator<EditGuestRequest>
  {
    public EditGuestRequestValidator()
    {
      RuleFor(x => x.guest).SetValidator(new GuestValidatorEdit());
    }
  }
}
