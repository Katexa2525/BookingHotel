using Application.DTO.Booking;
using Application.DTO.Hotel;

namespace Application.Interfaces.Recommendation
{
  public interface IRecommendationsService
  {
    /// <summary> Рекомендации на основе предпочтений пользователя по удобствам </summary>
    /// <param name="allUserBookings">Все бронирования зарегистрированного пользователя</param>
    /// <param name="allHotels">Список отелей</param>
    /// <param name="topN">Кол-во лучших отелей для вывода</param>
    /// <returns></returns>
    Task<IEnumerable<HotelDto>> RecommendHotelsAsync(
        IEnumerable<BookingDto> allUserBookings, IEnumerable<HotelDto> allHotels, int topN = 5);
  }
}
