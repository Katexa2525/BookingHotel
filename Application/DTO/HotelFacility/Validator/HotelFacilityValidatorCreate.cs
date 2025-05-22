using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.HotelFacility.Validator
{
  public class HotelFacilityValidatorCreate : AbstractValidator<HotelFacilityCreateDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public HotelFacilityValidatorCreate()
    {
      RuleFor(x => x.Name).NotEmpty().WithMessage(AppMessage.ValidatorHotelFacilityNameMessage);
    }
  }
}
