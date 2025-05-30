using Application.DTO.HotelPhoto.Validator;
using FluentValidation;

namespace Application.DTO.HotelPhoto.ClientRequest
{
  public class EditHotelPhotoRequestValidator : AbstractValidator<EditHotelPhotoRequest>
  {
    public EditHotelPhotoRequestValidator()
    {
      RuleFor(x => x.hotelPhoto).SetValidator(new HotelPhotoValidatorEdit());
    }
  }
}
