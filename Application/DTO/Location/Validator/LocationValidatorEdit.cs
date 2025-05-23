using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.Location.Validator
{
  public class LocationValidatorEdit : AbstractValidator<LocationDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public LocationValidatorEdit()
    {
      RuleFor(x => x.Name).NotEmpty().WithMessage(AppMessage.ValidatorLocationNameMessage);
    }
  }
}
