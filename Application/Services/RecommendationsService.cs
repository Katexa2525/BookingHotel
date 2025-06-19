using Application.DTO.Booking;
using Application.DTO.Hotel;
using Application.DTO.HotelFacility;
using Application.Interfaces.Recommendation;

namespace Application.Services
{
  public class RecommendationsService : IRecommendationsService
  {
    // Рекомендации на основе предпочтений пользователя
    public IEnumerable<HotelDto> RecommendHotelsByHotelFacilities(
        IEnumerable<BookingDto> allUserBookings, IEnumerable<HotelDto> allHotels, int topN)
    {
      var userPreferences = new HashSet<string>();
      List<Guid> userBookedHotels = new List<Guid>();

      // Собираем удобства из отелей, которые бронировал пользователь
      foreach (var booking in allUserBookings)
      {
        userBookedHotels.Add(booking.Room.HotelId);
        var hotel = allHotels.FirstOrDefault(h => h.Id == booking.Room.HotelId);
        if (hotel != null)
        {
          foreach (HotelFacilityDto amenity in hotel.HotelFacilities)
          {
            userPreferences.Add(amenity.Name);
          }
        }
      }

      // Рекомендуем отели с похожими удобствами
      var recommendations = allHotels
          .Where(h => !userBookedHotels.Contains(h.Id))
          .OrderByDescending(h => h.Star)
          //.OrderByDescending(h => h.HotelFacilities.Count(
          //                           a => userPreferences.Contains(a.Name)))
          .ThenByDescending(h => h.Rating)
          .Take(topN)
          //.Select()
          .ToList();

      //Enumerable.Empty<HotelDto>()
      return recommendations != null ? recommendations : new List<HotelDto>();
    }
  }
}
