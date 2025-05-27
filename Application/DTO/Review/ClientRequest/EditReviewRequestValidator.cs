using Application.DTO.Review.Validator;
using FluentValidation;

namespace Application.DTO.Review.ClientRequest
{
  public class EditReviewRequestValidator : AbstractValidator<EditReviewRequest>
  {
    public EditReviewRequestValidator()
    {
      RuleFor(x => x.review).SetValidator(new ReviewValidatorEdit());
    }
  }
}
