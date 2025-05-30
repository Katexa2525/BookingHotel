using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.HotelPhoto.Validator
{
  public class HotelPhotoValidatorEdit : AbstractValidator<HotelPhotoDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public HotelPhotoValidatorEdit()
    {
      RuleFor(x => x.HotelId).NotEmpty().WithMessage(AppMessage.ValidatorHotelPhotoNameMessage);
    }
  }
}
