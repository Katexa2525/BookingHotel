using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.RoomPhoto.Validator
{
  public class RoomPhotoValidatorCreate : AbstractValidator<RoomPhotoCreateWithIdDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public RoomPhotoValidatorCreate()
    {
      RuleFor(x => x.RoomId).NotEmpty().WithMessage(AppMessage.ValidatorRoomPhotoNameMessage);
    }
  }
}
