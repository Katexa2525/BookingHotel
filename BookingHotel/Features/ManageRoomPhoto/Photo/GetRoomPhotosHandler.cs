using Application.DTO.RoomPhoto;
using Application.DTO.RoomPhoto.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageRoomPhoto.Photo
{
  public class GetRoomPhotosHandler : IRequestHandler<GetRoomPhotosRequest, GetRoomPhotosRequest.Response?>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public GetRoomPhotosHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<GetRoomPhotosRequest.Response?> Handle(GetRoomPhotosRequest request, CancellationToken cancellationToken)
    {
      try
      {
        HttpClient? httpClient = _httpClientFactory.CreateClient("NoAuthenticationClient");

        //Заполнитель roomId в RouteTemplate заменяется идентификатором номера отеля, подлежащему редактированию, перед выполнением HTTP-запроса
        string route = GetRoomPhotosRequest.RouteTemplate.Replace("{roomId}", request.roomId.ToString());

        // Выполняется запрос к API. В случае успеха ответ десериализуется и возвращается вызывающей стороне
        var allPhotos = await httpClient.GetFromJsonAsync<List<RoomPhotoDto>>(route, cancellationToken);
        if (allPhotos == null)
          return new GetRoomPhotosRequest.Response(new List<RoomPhotoDto>());
        else
          return new GetRoomPhotosRequest.Response(allPhotos);

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
