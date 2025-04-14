using FluentValidation;

namespace Application.DTO.Hotel.Validator
{
    /// <summary>Класс валидации для модели HotelDto </summary>
    public class HotelValidator : AbstractValidator<HotelDto>
    {
        /// <summary> Конструктор класса с правилами валидации </summary>
        public HotelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Пожалуйста введите наименование отеля");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Пожалуйста введите описание отеля");
            RuleFor(x => x.Location).NotEmpty().WithMessage("Пожалуйста введите местоположение отеля");
            RuleFor(x => x.Star).NotEmpty().WithMessage("Пожалуйста введите кол-во звезд у отеля");
        }
    }
}
