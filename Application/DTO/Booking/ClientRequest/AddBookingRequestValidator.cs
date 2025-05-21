using Application.DTO.Booking.Validator;
using FluentValidation;

namespace Application.DTO.Booking.ClientRequest
{
  public class AddBookingRequestValidator : AbstractValidator<AddBookingRequest>
  {
    public AddBookingRequestValidator()
    {
      RuleFor(p => p.Booking).SetValidator(new BookingValidatorCreate());
    }
  }
}
