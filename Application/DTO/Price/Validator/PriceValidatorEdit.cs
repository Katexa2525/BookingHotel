using Application.ConstMessages;
using FluentValidation;

namespace Application.DTO.Price.Validator
{
  public class PriceValidatorEdit : AbstractValidator<PriceDto>
  {
    /// <summary> Конструктор класса с правилами валидации </summary>
    public PriceValidatorEdit()
    {
      RuleFor(x => x.RoomId).NotEmpty().WithMessage(AppMessage.ValidatorPriceRoomIdMessage);
      RuleFor(x => x.CurrencyId).NotEmpty().WithMessage(AppMessage.ValidatorPriceCurrencyIdMessage);
      RuleFor(x => x.DateStart).NotEmpty().WithMessage(AppMessage.ValidatorPriceDateStartMessage);
      RuleFor(x => x.DateEnd).NotEmpty().WithMessage(AppMessage.ValidatorPriceDateEndMessage);
      RuleFor(x => x.DayPrice).NotEmpty().WithMessage(AppMessage.ValidatorPriceDayPriceMessage);
    }
  }
}
