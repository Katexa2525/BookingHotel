using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.RoomPhoto.Validator
{
  public class RoomPhotoValidatorEdit : AbstractValidator<RoomPhotoDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public RoomPhotoValidatorEdit()
    {
      RuleFor(x => x.RoomId).NotEmpty().WithMessage(AppMessage.ValidatorRoomPhotoNameMessage);
    }
  }
}
