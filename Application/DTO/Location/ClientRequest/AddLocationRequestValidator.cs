using Application.DTO.Location.Validator;
using FluentValidation;

namespace Application.DTO.Location.ClientRequest
{
  public class AddLocationRequestValidator : AbstractValidator<AddLocationRequest>
  {
    public AddLocationRequestValidator()
    {
      RuleFor(p => p.Location).SetValidator(new LocationValidatorCreate());
    }
  }
}
