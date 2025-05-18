using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.Room.Validator
{
  public class RoomValidatorEdit : AbstractValidator<RoomDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public RoomValidatorEdit()
    {
      RuleFor(x => x.PeopleNumber).NotEmpty().WithMessage(AppMessage.ValidatorRoomPeopleNumberMessage);
      RuleFor(x => x.Description).NotEmpty().WithMessage(AppMessage.ValidatorRoomDescriptionMessage);
      RuleFor(x => x.Square).NotEmpty().WithMessage(AppMessage.ValidatorRoomSquareMessage);
    }
  }
}
