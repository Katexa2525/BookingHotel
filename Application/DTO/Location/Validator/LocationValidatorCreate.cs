using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.Location.Validator
{
  public class LocationValidatorCreate : AbstractValidator<LocationCreateWithIdDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public LocationValidatorCreate()
    {
      RuleFor(x => x.Name).NotEmpty().WithMessage(AppMessage.ValidatorLocationNameMessage);
    }
  }
}
