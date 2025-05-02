using Application.DTO.Hotel.Validator;
using FluentValidation;

namespace Application.DTO.Hotel.ClientRequest
{
  /// <summary>Класс валидатора запроса для создания отеля. Он будте выполняться API, чтобы убедиться что данные корректны </summary>
  public class AddHotelRequestValidator : AbstractValidator<AddHotelRequest>
  {
    public AddHotelRequestValidator()
    {
      // Определяет HotelValidator в качестве валидатора свойства Hotel.
      // Позволяет повторно использовать созданные ранее правила валидации
      RuleFor(p => p.Hotel).SetValidator(new HotelValidatorCreate());
    }
  }
}
