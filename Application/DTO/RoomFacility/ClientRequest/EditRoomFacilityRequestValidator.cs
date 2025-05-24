using Application.DTO.RoomFacility.Validator;
using FluentValidation;

namespace Application.DTO.RoomFacility.ClientRequest
{
  public class EditRoomFacilityRequestValidator : AbstractValidator<EditRoomFacilityRequest>
  {
    public EditRoomFacilityRequestValidator()
    {
      RuleFor(x => x.roomFacility).SetValidator(new RoomFacilityValidatorEdit());
    }
  }
}
