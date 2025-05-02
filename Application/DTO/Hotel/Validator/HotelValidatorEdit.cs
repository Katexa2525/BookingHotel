using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.Hotel.Validator
{
  /// <summary>Класс валидатора запроса для редактирования отеля. Он будте выполняться API, чтобы убедиться что данные корректны </summary>
  public class HotelValidatorEdit : AbstractValidator<HotelDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public HotelValidatorEdit()
    {
      RuleFor(x => x.Name).NotEmpty().WithMessage(AppMessage.ValidatorHotelNameMessage);
      RuleFor(x => x.Description).NotEmpty().WithMessage(AppMessage.ValidatorHotelDescriptionMessage);
      RuleFor(x => x.Location).NotEmpty().WithMessage(AppMessage.ValidatorHotelLocationMessage);
      RuleFor(x => x.Star).NotEmpty().WithMessage(AppMessage.ValidatorHotelStarMessage);
    }
  }
}
