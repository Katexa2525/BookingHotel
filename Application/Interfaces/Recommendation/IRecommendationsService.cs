using Application.DTO.Booking;
using Application.DTO.Hotel;

namespace Application.Interfaces.Recommendation
{
  public interface IRecommendationsService
  {
    // Рекомендации на основе предпочтений пользователя по удобствам
    IEnumerable<HotelDto> RecommendHotelsByHotelFacilities(
        IEnumerable<BookingDto> allUserBookings, IEnumerable<HotelDto> allHotels, int topN = 5);
  }
}
