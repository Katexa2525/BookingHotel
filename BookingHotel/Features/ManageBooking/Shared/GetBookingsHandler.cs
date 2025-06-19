using Application.DTO.Booking;
using Application.DTO.Booking.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageBooking.Shared
{
  public class GetBookingsHandler : IRequestHandler<GetBookingsRequest, GetBookingsRequest.Response?>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public GetBookingsHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<GetBookingsRequest.Response?> Handle(GetBookingsRequest request, CancellationToken cancellationToken)
    {
      try
      {
        HttpClient? httpClient = _httpClientFactory.CreateClient("NoAuthenticationClient");

        // Выполняется запрос к API. В случае успеха ответ десериализуется и возвращается вызывающей стороне
        var allBookings = await httpClient.GetFromJsonAsync<List<BookingAllDto>>(GetBookingsRequest.RouteTemplate, cancellationToken);
        return new GetBookingsRequest.Response(allBookings);
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
