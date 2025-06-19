using Application.DTO.Booking;
using Application.DTO.Booking.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageBooking.Shared
{
  public class GetBookingsByUserIdHandler : IRequestHandler<GetBookingsByUserIdRequest, GetBookingsByUserIdRequest.Response?>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public GetBookingsByUserIdHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<GetBookingsByUserIdRequest.Response?> Handle(GetBookingsByUserIdRequest request, CancellationToken cancellationToken)
    {
      try
      {
        HttpClient? httpClient = _httpClientFactory.CreateClient("NoAuthenticationClient");

        //Заполнитель userId в RouteTemplate заменяется идентификатором пользователя, подлежащему редактированию, перед выполнением HTTP-запроса
        string route = GetBookingsByUserIdRequest.RouteTemplate.Replace("{userId}", request.userId.ToString());

        // Выполняется запрос к API. В случае успеха ответ десериализуется и возвращается вызывающей стороне
        var allBookings = await httpClient.GetFromJsonAsync<List<BookingDto>>(route, cancellationToken);
        if (allBookings == null)
          return new GetBookingsByUserIdRequest.Response(new List<BookingDto>());
        else
          return new GetBookingsByUserIdRequest.Response(allBookings);
      }
      catch (HttpRequestException)
      {
        //В противном случае вызывающая сторона получает в качестве ответа null
        return default!;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return default!;
      }
    }
  }
}
