using Application.DTO.RoomPhoto.Validator;
using FluentValidation;

namespace Application.DTO.RoomPhoto.ClientRequest
{
  public class AddRoomPhotoRequestValidator : AbstractValidator<AddRoomPhotoRequest>
  {
    public AddRoomPhotoRequestValidator()
    {
      RuleFor(p => p.RoomPhoto).SetValidator(new RoomPhotoValidatorCreate());
    }
  }
}
