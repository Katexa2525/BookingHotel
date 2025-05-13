using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.Hotel.Validator
{
  /// <summary>Класс валидации для модели HotelDto </summary>
  public class HotelValidatorCreate : AbstractValidator<HotelCreateDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public HotelValidatorCreate()
    {
      RuleFor(x => x.Name).NotEmpty().WithMessage(AppMessage.ValidatorHotelNameMessage);
      RuleFor(x => x.Description).NotEmpty().WithMessage(AppMessage.ValidatorHotelDescriptionMessage);
      RuleFor(x => x.Location).NotEmpty().WithMessage(AppMessage.ValidatorHotelLocationMessage);
      RuleFor(x => x.Star).NotEmpty().WithMessage(AppMessage.ValidatorHotelStarMessage);
      RuleFor(x => x.Arrival).NotEmpty().WithMessage(AppMessage.ValidatorHotelArrivalMessage);
      RuleFor(x => x.Departure).NotEmpty().WithMessage(AppMessage.ValidatorHotelDepartureMessage);
    }
  }
}
