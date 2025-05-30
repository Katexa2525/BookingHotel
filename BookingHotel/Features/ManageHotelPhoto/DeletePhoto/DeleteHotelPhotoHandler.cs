using Application.DTO.HotelPhoto.ClientRequest;
using MediatR;

namespace BookingHotel.Features.ManageHotelPhoto.DeletePhoto
{
  public class DeleteHotelPhotoHandler : IRequestHandler<DeleteHotelPhotoRequest, DeleteHotelPhotoRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public DeleteHotelPhotoHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<DeleteHotelPhotoRequest.Response> Handle(DeleteHotelPhotoRequest request, CancellationToken cancellationToken)
    {
      try
      {
        // Защищенный HttpClient используется для вызова API с использованием шаблона маршрута, который определили для запроса
        HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");
        //Заполнитель priceId в RouteTemplate заменяется идентификатором, подлежащему редактированию, перед выполнением HTTP-запроса
        string route = DeleteHotelPhotoRequest.RouteTemplate.Replace("{photoId}", request.photoId.ToString());

        var requestDel = new HttpRequestMessage(HttpMethod.Delete, route);

        var response = await httpClient.SendAsync(requestDel);

        if (response.IsSuccessStatusCode)
        {
          return new DeleteHotelPhotoRequest.Response(true);
        }
        else
        {
          // если запрос не выполнен
          return new DeleteHotelPhotoRequest.Response(false);
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
