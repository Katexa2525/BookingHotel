using Application.DTO.Booking.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageBooking.AddBooking
{
  public class AddBookingHandler : IRequestHandler<AddBookingRequest, AddBookingRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public AddBookingHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<AddBookingRequest.Response> Handle(AddBookingRequest request, CancellationToken cancellationToken)
    {
      try
      {
        // Защищенный HttpClient используется для вызова API с использованием шаблона маршрута, который определили для запроса
        HttpClient? httpClient = _httpClientFactory.CreateClient("NoAuthenticationClient");
        var response = await httpClient.PostAsJsonAsync(AddBookingRequest.RouteTemplate, request, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
          Guid bookingId = await response.Content.ReadFromJsonAsync<Guid>(cancellationToken);
          // если запрос был успешным, то bookingId считывается из ответа и возвращается с помощью записи AddBookingRequest.Response
          return new AddBookingRequest.Response(bookingId);
        }
        else
        {
          // если запрос не выполнен
          return new AddBookingRequest.Response(Guid.Empty);
        }
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
