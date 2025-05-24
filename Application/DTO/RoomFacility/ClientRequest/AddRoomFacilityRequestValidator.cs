using Application.DTO.RoomFacility.Validator;
using FluentValidation;

namespace Application.DTO.RoomFacility.ClientRequest
{
  public class AddRoomFacilityRequestValidator : AbstractValidator<AddRoomFacilityRequest>
  {
    public AddRoomFacilityRequestValidator()
    {
      RuleFor(p => p.RoomFacility).SetValidator(new RoomFacilityValidatorCreate());
    }
  }
}
