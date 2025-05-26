using Application.DTO.RoomPhoto.Validator;
using FluentValidation;

namespace Application.DTO.RoomPhoto.ClientRequest
{
  public class EditRoomPhotoRequestValidator : AbstractValidator<EditRoomPhotoRequest>
  {
    public EditRoomPhotoRequestValidator()
    {
      RuleFor(x => x.roomPhoto).SetValidator(new RoomPhotoValidatorEdit());
    }
  }
}
