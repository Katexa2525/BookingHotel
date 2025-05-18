using Application.DTO.Room.Validator;
using FluentValidation;

namespace Application.DTO.Room.ClientRequest
{
  public class AddRoomRequestValidator : AbstractValidator<AddRoomRequest>
  {
    public AddRoomRequestValidator()
    {
      RuleFor(p => p.Room).SetValidator(new RoomValidatorCreate());
    }
  }
}
