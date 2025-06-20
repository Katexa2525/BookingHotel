using Application.DTO.Booking;
using Application.DTO.Booking.ClientRequest;
using Application.DTO.Hotel;
using Application.Interfaces.Recommendation;
using Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
  public class RecommendationsService : IRecommendationsService
  {
    private readonly IMediator _mediator;

    public RecommendationsService(IMediator mediator)
    {
      _mediator = mediator;
    }

    // Рекомендации на основе предпочтений пользователя
    public async Task<IEnumerable<HotelDto>> RecommendHotelsAsync(IEnumerable<BookingDto> allUserBookings, IEnumerable<HotelDto> allHotels, int topN)
    {
      var userHotelFacilities = new HashSet<string>();
      var userHotelLocations = new HashSet<string>();
      var userHotelFoods = new HashSet<string>();
      var userRoomFacilities = new HashSet<string>();
      List<Guid> userBookedHotels = new List<Guid>();

      await RecommendHotelsByFindSimilarUsersAsync(allUserBookings, allHotels, topN);

      // Собираем удобства из отелей, которые бронировал пользователь
      foreach (var booking in allUserBookings)
      {
        userBookedHotels.Add(booking.Room.HotelId);
        var hotel = allHotels.FirstOrDefault(h => h.Id == booking.Room.HotelId);
        if (hotel != null)
        {
          // удобства по отелю
          foreach (var item in hotel.HotelFacilities)
          {
            userHotelFacilities.Add(item.Name);
          }
          // локации отеля
          foreach (var item in hotel.Locations)
          {
            userHotelLocations.Add(item.Name);
          }
          // питание отеля
          foreach (var item in hotel.Foods)
          {
            userHotelFoods.Add(item.Name);
          }
          // удобства по номерам
          //foreach (var room in hotel.Rooms)
          //{
          //  foreach (var item in room.RoomFacilities)
          //  {
          //    userRoomFacilities.Add(item.Name);
          //  }
          //}

        }
      }

      // Рекомендуем отели с похожими удобствами
      var recommendations = allHotels
          .Where(h => !userBookedHotels.Contains(h.Id))
          .OrderByDescending(h => h.HotelFacilities.Count(fac => userHotelFacilities.Contains(fac.Name)))
          .ThenByDescending(h => h.Foods.Count(food => userHotelFoods.Contains(food.Name)))
          .ThenByDescending(h => h.Locations.Count(loc => userHotelLocations.Contains(loc.Name)))
          .ThenByDescending(h => h.Star).ThenByDescending(h => h.Rating)
          .Take(topN)
          //.Select()
          .ToList();

      //Enumerable.Empty<HotelDto>()
      return recommendations != null ? recommendations : new List<HotelDto>();
    }

    /// <summary> Метод поиска похожих пользователей </summary>
    /// <param name="targetUserId">Id зарегистрированного пользователя</param>
    /// <param name="allUserBookings">Бронирования зарегистрированного пользователя</param>
    /// /// <param name="allHotels">Список отелей</param>
    /// <returns></returns>
    private Dictionary<string, double> FindSimilarUsers(string targetUserId, IEnumerable<BookingDto> allUserBookings, 
                                                        IEnumerable<HotelDto> allHotels, IEnumerable<BookingDto> AllBookings)
    {
      var similarUsers = new Dictionary<string, double>();
      // получаю все бронирования
      //var responseAllBookings = await _mediator.Send(new GetBookingsRequest());

      if (AllBookings != null && AllBookings != null)
      {
        foreach (IGrouping<string?, BookingDto> userGroup in AllBookings.GroupBy(b => b.UserId))
        {
          if (userGroup.Key == targetUserId) continue;

          Console.WriteLine($"userGroup.Key: {userGroup.Key}");

          List<BookingDto>? commonBookings = new List<BookingDto>();
          foreach (var item in userGroup)
          {
            if (item.Room != null && userGroup.Any(u => u.Room != null && item.Room.HotelId == u.Room.HotelId))
            {
              commonBookings.Add(item);
            }
          } 

          if (commonBookings != null && commonBookings.Any())
          {
            foreach (var booking in commonBookings)
            {
              // Простая мера схожести (можно заменить на косинусное сходство)
              double similarity = allHotels.Where(p => booking.Room != null && p.Id == booking.Room.HotelId).Average(b => b.Rating);
              if (userGroup.Key is not null)
                similarUsers.Add(userGroup.Key, similarity);
            }
          }
        }
      }
      if (similarUsers.Any())
        return similarUsers.OrderByDescending(u => u.Value).ToDictionary(x => x.Key, x => x.Value);
      return similarUsers;
    }

    private async Task<IEnumerable<HotelDto>> RecommendHotelsByFindSimilarUsersAsync(IEnumerable<BookingDto> allUserBookings, IEnumerable<HotelDto> allHotels, int topN)
    {
      Dictionary<string, double> similarUsers = new Dictionary<string, double>();
      List<Guid>? recommendedUsersHotels = new List<Guid>();
      try
      {
        // рекомендации на основе схожести бронирования других пользователей
        if (allUserBookings is not null && allUserBookings.First() is not null)
        {
          // получаю все бронирования
          var responseAllBookings = await _mediator.Send(new GetBookingsRequest());
          if (responseAllBookings != null && responseAllBookings.Bookings != null)
          {
            // нахожу похожих пользователей
            similarUsers = FindSimilarUsers(allUserBookings.First().UserId, allUserBookings, allHotels, responseAllBookings.Bookings);
            if (similarUsers != null && similarUsers.Any())
            {
              foreach (var user in similarUsers)
              {
                // получаю отели по пользователю
                //var responseBookings = await _mediator.Send(new GetBookingsByUserIdRequest(user.Key));
                //Берем топовые отели похожего пользователя (оценка >= 4)
                var userTopHotels = responseAllBookings.Bookings.Where(b => b.UserId == user.Key)
                                                                           .Select(b => b.Room.HotelId).Distinct().Take(topN);
                recommendedUsersHotels.AddRange(userTopHotels);
              }
              // Удаляю дубликаты и отели, которые пользователь уже бронировал
              var bookedHotels = responseAllBookings.Bookings
                  .Where(b => b.UserId == allUserBookings.First().UserId)
                  .Select(b => b.Room.HotelId)
                  .ToList();
            
              allHotels.Where(h => !bookedHotels.Contains(h.Id)).Distinct().Take(topN).ToList();
            }
          }
        }
      }
      catch (Exception ex)
      {
        if (ex.InnerException != null)
          Console.WriteLine($"Error: {ex.InnerException.Message}");
        else
          Console.WriteLine($"Error: {ex.Message}");
      }
      return allHotels;
    }

  }
}
