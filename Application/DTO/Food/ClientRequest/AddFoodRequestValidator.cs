using Application.DTO.Food.Validator;
using FluentValidation;

namespace Application.DTO.Food.ClientRequest
{
  public class AddFoodRequestValidator : AbstractValidator<AddFoodRequest>
  {
    public AddFoodRequestValidator()
    {
      // Определяет HotelValidator в качестве валидатора свойства Hotel.
      // Позволяет повторно использовать созданные ранее правила валидации
      RuleFor(p => p.Food).SetValidator(new FoodValidatorCreate());
    }
  }
}
