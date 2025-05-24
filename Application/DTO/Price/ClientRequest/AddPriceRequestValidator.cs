using Application.DTO.Price.Validator;
using FluentValidation;

namespace Application.DTO.Price.ClientRequest
{
  public class AddPriceRequestValidator : AbstractValidator<AddPriceRequest>
  {
    public AddPriceRequestValidator()
    {
      RuleFor(p => p.Price).SetValidator(new PriceValidatorCreate());
    }
  }
}
