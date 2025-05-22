using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.HotelFacility.Validator
{
  public class HotelFacilityValidatorEdit : AbstractValidator<HotelFacilityDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public HotelFacilityValidatorEdit()
    {
      RuleFor(x => x.Name).NotEmpty().WithMessage(AppMessage.ValidatorHotelFacilityNameMessage);
    }
  }
}
