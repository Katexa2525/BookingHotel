using Application.DTO.Price.Validator;
using FluentValidation;

namespace Application.DTO.Price.ClientRequest
{
  public class EditPriceRequestValidator : AbstractValidator<EditPriceRequest>
  {
    public EditPriceRequestValidator()
    {
      RuleFor(x => x.price).SetValidator(new PriceValidatorEdit());
    }
  }
}
