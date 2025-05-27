using Application.DTO.Review.Validator;
using FluentValidation;

namespace Application.DTO.Review.ClientRequest
{
  public class AddReviewRequestValidator : AbstractValidator<AddReviewRequest>
  {
    public AddReviewRequestValidator()
    {
      RuleFor(p => p.Review).SetValidator(new ReviewValidatorCreate());
    }
  }
}
