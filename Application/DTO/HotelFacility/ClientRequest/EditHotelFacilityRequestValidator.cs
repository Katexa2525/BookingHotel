using Application.DTO.HotelFacility.Validator;
using FluentValidation;

namespace Application.DTO.HotelFacility.ClientRequest
{
  public class EditHotelFacilityRequestValidator : AbstractValidator<EditHotelFacilityRequest>
  {
    public EditHotelFacilityRequestValidator()
    {
      RuleFor(x => x.hotelFacility).SetValidator(new HotelFacilityValidatorEdit());
    }
  }
}
