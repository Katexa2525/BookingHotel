using Application.DTO.Room.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageRoom.AddRoom
{
  public class AddRoomHandler : IRequestHandler<AddRoomRequest, AddRoomRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public AddRoomHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<AddRoomRequest.Response> Handle(AddRoomRequest request, CancellationToken cancellationToken)
    {
      try
      {
        // Защищенный HttpClient используется для вызова API с использованием шаблона маршрута, который определили для запроса
        HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");
        //httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        var response = await httpClient.PostAsJsonAsync(AddRoomRequest.RouteTemplate, request, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
          Guid roomId = await response.Content.ReadFromJsonAsync<Guid>(cancellationToken);
          // если запрос был успешным, то roomId считывается из ответа и возвращается с помощью записи AddRoomRequest.Response
          return new AddRoomRequest.Response(roomId);
        }
        else
        {
          // если запрос не выполнен
          return new AddRoomRequest.Response(Guid.Empty);
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
