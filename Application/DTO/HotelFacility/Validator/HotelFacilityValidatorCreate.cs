using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.HotelFacility.Validator
{
  public class HotelFacilityValidatorCreate : AbstractValidator<HotelFacilityCreateWithIdDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public HotelFacilityValidatorCreate()
    {
      RuleFor(x => x.Name).NotEmpty().WithMessage(AppMessage.ValidatorHotelFacilityNameMessage);
    }
  }
}
