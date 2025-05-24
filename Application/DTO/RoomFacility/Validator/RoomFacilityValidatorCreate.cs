using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.RoomFacility.Validator
{
  public class RoomFacilityValidatorCreate : AbstractValidator<RoomFacilityCreateWithIdDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public RoomFacilityValidatorCreate()
    {
      RuleFor(x => x.Name).NotEmpty().WithMessage(AppMessage.ValidatorRoomFacilityNameMessage);
    }
  }
}
