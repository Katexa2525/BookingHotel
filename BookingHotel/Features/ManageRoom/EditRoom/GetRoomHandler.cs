using Application.DTO.Room;
using Application.DTO.Room.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageRoom.EditRoom
{
  public class GetRoomHandler : IRequestHandler<GetRoomRequest, GetRoomRequest.Response?>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public GetRoomHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<GetRoomRequest.Response?> Handle(GetRoomRequest request, CancellationToken cancellationToken)
    {
      try
      {
        // Незащищенный HttpClient используется для вызова API с использованием шаблона маршрута, который определили для запроса
        HttpClient? httpClient = _httpClientFactory.CreateClient("NoAuthenticationClient");

        string route = GetRoomRequest.RouteTemplate.Replace("{roomId}", request.roomId.ToString());

        var res = await httpClient.GetFromJsonAsync<RoomDto?>(route, cancellationToken);

        return new GetRoomRequest.Response(res);
      }
      catch (HttpRequestException ex)
      {
        Console.WriteLine(ex.Message);
        return default!;
      }
    }
  }
}
