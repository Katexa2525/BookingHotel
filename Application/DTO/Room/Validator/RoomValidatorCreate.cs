using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.Room.Validator
{
  public class RoomValidatorCreate : AbstractValidator<RoomCreateDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public RoomValidatorCreate()
    {
      RuleFor(x => x.HotelId).NotEmpty().WithMessage(AppMessage.ValidatorRoomHotelIdNumberMessage);
      RuleFor(x => x.RoomTypeId).NotEmpty().WithMessage(AppMessage.ValidatorRoomTypeIdNumberMessage);
      RuleFor(x => x.PeopleNumber).NotEmpty().WithMessage(AppMessage.ValidatorRoomPeopleNumberMessage);
      RuleFor(x => x.Description).NotEmpty().WithMessage(AppMessage.ValidatorRoomDescriptionMessage);
      RuleFor(x => x.Square).NotEmpty().WithMessage(AppMessage.ValidatorRoomSquareMessage);
    }
  }
}
