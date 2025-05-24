using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.RoomFacility.Validator
{
  public class RoomFacilityValidatorEdit : AbstractValidator<RoomFacilityDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public RoomFacilityValidatorEdit()
    {
      RuleFor(x => x.Name).NotEmpty().WithMessage(AppMessage.ValidatorRoomFacilityNameMessage);
    }
  }
}
