using Application.DTO.Food.Validator;
using FluentValidation;

namespace Application.DTO.Food.ClientRequest
{
  public class EditFoodRequestValidator : AbstractValidator<EditFoodRequest>
  {
    public EditFoodRequestValidator()
    {
      RuleFor(x => x.food).SetValidator(new FoodValidatorEdit());
    }
  }
}
