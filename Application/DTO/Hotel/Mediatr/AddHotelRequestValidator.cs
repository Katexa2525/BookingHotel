using Application.DTO.Hotel;
using FluentValidation;

namespace BookingHotel.Features.ManageHotel.Mediatr
{
  /// <summary>Класс валидатора запроса. Он будте выполняться API, чтобы убедиться что данные корректны </summary>
  public class AddHotelRequestValidator :AbstractValidator<AddHotelRequest>
  {
    public AddHotelRequestValidator() 
    {
      // Определяет HotelValidator в качестве валидатора свойства Hotel.
      // Позволяет повторно использовать созданные нами ранее правила валидации
      RuleFor(p => p.Hotel).SetValidator(new HotelValidator());
    }
  }
}
