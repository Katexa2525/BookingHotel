using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.HotelPhoto.Validator
{
  public class HotelPhotoValidatorCreate : AbstractValidator<HotelPhotoCreateWithIdDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public HotelPhotoValidatorCreate()
    {
      RuleFor(x => x.HotelId).NotEmpty().WithMessage(AppMessage.ValidatorHotelPhotoNameMessage);
    }
  }
}
