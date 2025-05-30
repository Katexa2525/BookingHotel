using Application.DTO.HotelPhoto;
using Application.DTO.HotelPhoto.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageHotelPhoto.Photo
{
  public class GetHotelPhotosHandler : IRequestHandler<GetHotelPhotosRequest, GetHotelPhotosRequest.Response?>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public GetHotelPhotosHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<GetHotelPhotosRequest.Response?> Handle(GetHotelPhotosRequest request, CancellationToken cancellationToken)
    {
      try
      {
        HttpClient? httpClient = _httpClientFactory.CreateClient("NoAuthenticationClient");

        //Заполнитель roomId в RouteTemplate заменяется идентификатором отеля, подлежащему редактированию, перед выполнением HTTP-запроса
        string route = GetHotelPhotosRequest.RouteTemplate.Replace("{hotelId}", request.hotelId.ToString());

        // Выполняется запрос к API. В случае успеха ответ десериализуется и возвращается вызывающей стороне
        var allPhotos = await httpClient.GetFromJsonAsync<List<HotelPhotoDto>>(route, cancellationToken);
        if (allPhotos == null)
          return new GetHotelPhotosRequest.Response(new List<HotelPhotoDto>());
        else
          return new GetHotelPhotosRequest.Response(allPhotos);

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
