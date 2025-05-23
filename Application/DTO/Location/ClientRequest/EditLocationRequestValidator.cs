using Application.DTO.Location.Validator;
using FluentValidation;

namespace Application.DTO.Location.ClientRequest
{
  public class EditLocationRequestValidator : AbstractValidator<EditLocationRequest>
  {
    public EditLocationRequestValidator()
    {
      RuleFor(x => x.location).SetValidator(new LocationValidatorEdit());
    }
  }
}
