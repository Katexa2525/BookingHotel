using Application.DTO.HotelPhoto.Validator;
using FluentValidation;

namespace Application.DTO.HotelPhoto.ClientRequest
{
  public class AddHotelPhotoRequestValidator : AbstractValidator<AddHotelPhotoRequest>
  {
    public AddHotelPhotoRequestValidator()
    {
      RuleFor(p => p.HotelPhoto).SetValidator(new HotelPhotoValidatorCreate());
    }
  }
}
