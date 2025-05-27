using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.Review.Validator
{
  public class ReviewValidatorEdit : AbstractValidator<ReviewDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public ReviewValidatorEdit()
    {
      RuleFor(x => x.HotelId).NotEmpty().WithMessage(AppMessage.ValidatorReviewHotelIdMessage);
      RuleFor(x => x.Name).NotEmpty().WithMessage(AppMessage.ValidatorReviewNameMessage);
      RuleFor(x => x.Description).NotEmpty().WithMessage(AppMessage.ValidatorReviewDescriptionMessage);
      RuleFor(x => x.Star).NotEmpty().WithMessage(AppMessage.ValidatorReviewStarMessage);
    }
  }
}
