using Application.DTO.Hotel.Validator;
using FluentValidation;

namespace Application.DTO.Hotel.ClientRequest
{
  public class EditHotelRequestValidator : AbstractValidator<EditHotelRequest>
  {
    public EditHotelRequestValidator()
    {
      RuleFor(x => x.hotel).SetValidator(new HotelValidatorEdit());
    }
  }
}
