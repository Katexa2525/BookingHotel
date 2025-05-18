using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.Room.Validator
{
  public class RoomValidatorCreate : AbstractValidator<RoomCreateDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public RoomValidatorCreate()
    {
      RuleFor(x => x.PeopleNumber).NotEmpty().WithMessage(AppMessage.ValidatorRoomPeopleNumberMessage);
      RuleFor(x => x.Description).NotEmpty().WithMessage(AppMessage.ValidatorHotelDescriptionMessage);
      RuleFor(x => x.Square).NotEmpty().WithMessage(AppMessage.ValidatorRoomSquareMessage);
    }
  }
}
