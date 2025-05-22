using Application.DTO.HotelFacility.Validator;
using FluentValidation;

namespace Application.DTO.HotelFacility.ClientRequest
{
  public class AddHotelFacilityRequestValidator : AbstractValidator<AddHotelFacilityRequest>
  {
    public AddHotelFacilityRequestValidator()
    {
      RuleFor(p => p.HotelFacility).SetValidator(new HotelFacilityValidatorCreate());
    }
  }
}
