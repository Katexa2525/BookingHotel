using Application.DTO.Hotel.ClientRequest;
using Application.DTO.Room;
using Application.DTO.Room.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageRoom.Room
{
  public class GetRoomsHandler : IRequestHandler<GetRoomsRequest, GetRoomsRequest.Response?>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public GetRoomsHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<GetRoomsRequest.Response?> Handle(GetRoomsRequest request, CancellationToken cancellationToken)
    {
      try
      {
        HttpClient? httpClient = _httpClientFactory.CreateClient("NoAuthenticationClient");

        //Заполнитель hotelId в RouteTemplate заменяется идентификатором отеля, подлежащему редактированию, перед выполнением HTTP-запроса
        string route = GetRoomsRequest.RouteTemplate.Replace("{hotelId}", request.hotelId.ToString());

        // Выполняется запрос к API. В случае успеха ответ десериализуется и возвращается вызывающей стороне
        var allRooms = await httpClient.GetFromJsonAsync<List<RoomDto>>(route, cancellationToken);
        if (allRooms == null)
          return new GetRoomsRequest.Response(new List<RoomDto>());
        else 
          return new GetRoomsRequest.Response(allRooms);
      }
      catch (HttpRequestException ex)
      {
        Console.WriteLine(ex.Message);
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
