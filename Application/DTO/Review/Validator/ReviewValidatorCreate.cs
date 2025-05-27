using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.Review.Validator
{
  public class ReviewValidatorCreate : AbstractValidator<ReviewCreateWithIdDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public ReviewValidatorCreate()
    {
      RuleFor(x => x.HotelId).NotEmpty().WithMessage(AppMessage.ValidatorReviewHotelIdMessage);
      RuleFor(x => x.Name).NotEmpty().WithMessage(AppMessage.ValidatorReviewNameMessage);
      RuleFor(x => x.Description).NotEmpty().WithMessage(AppMessage.ValidatorReviewDescriptionMessage);
      RuleFor(x => x.Star).NotEmpty().WithMessage(AppMessage.ValidatorReviewStarMessage);
    }
  }
}
