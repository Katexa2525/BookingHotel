using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.Food.Validator
{
  public class FoodValidatorEdit : AbstractValidator<FoodDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public FoodValidatorEdit()
    {
      RuleFor(x => x.Name).NotEmpty().WithMessage(AppMessage.ValidatorFoodNameMessage);
      RuleFor(x => x.TypeFoodId).NotEmpty().WithMessage(AppMessage.ValidatorTypeFoodNameMessage);
      RuleFor(x => x.HotelId).NotEmpty().WithMessage(AppMessage.ValidatorHotelFoodNameMessage);
    }
  }
}
