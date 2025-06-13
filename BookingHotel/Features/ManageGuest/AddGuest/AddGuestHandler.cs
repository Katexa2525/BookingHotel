using Application.DTO.Guest.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageGuest.AddGuest
{
  public class AddGuestHandler : IRequestHandler<AddGuestRequest, AddGuestRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public AddGuestHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<AddGuestRequest.Response> Handle(AddGuestRequest request, CancellationToken cancellationToken)
    {
      try
      {
        // Защищенный HttpClient используется для вызова API с использованием шаблона маршрута, который определили для запроса
        HttpClient? httpClient = _httpClientFactory.CreateClient("NoAuthenticationClient");
        var response = await httpClient.PostAsJsonAsync(AddGuestRequest.RouteTemplate, request, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
          Guid guestId = await response.Content.ReadFromJsonAsync<Guid>(cancellationToken);
          // если запрос был успешным, то guestId считывается из ответа и возвращается с помощью записи AddGuestRequest.Response
          return new AddGuestRequest.Response(guestId);
        }
        else
        {
          // если запрос не выполнен
          return new AddGuestRequest.Response(Guid.Empty);
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
