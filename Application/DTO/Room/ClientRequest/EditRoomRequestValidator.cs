using Application.DTO.Room.Validator;
using FluentValidation;

namespace Application.DTO.Room.ClientRequest
{
  public class EditRoomRequestValidator : AbstractValidator<EditRoomRequest>
  {
    public EditRoomRequestValidator()
    {
      RuleFor(x => x.room).SetValidator(new RoomValidatorEdit());
    }
  }
}
