using Application.DTO.HotelFacility.ClientRequest;
using Application.DTO.Location.ClientRequest;
using MediatR;

namespace BookingHotel.Features.ManageLocation.DeleteLocation
{
  public class DeleteLocationHandler : IRequestHandler<DeleteLocationRequest, DeleteLocationRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public DeleteLocationHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<DeleteLocationRequest.Response> Handle(DeleteLocationRequest request, CancellationToken cancellationToken)
    {
      try
      {
        // Защищенный HttpClient используется для вызова API с использованием шаблона маршрута, который определили для запроса
        HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");
        //Заполнитель locationId в RouteTemplate заменяется идентификатором локаций отеля, подлежащему редактированию, перед выполнением HTTP-запроса
        string route = DeleteLocationRequest.RouteTemplate.Replace("{locationId}", request.locationId.ToString());

        var requestDel = new HttpRequestMessage(HttpMethod.Delete, route);

        var response = await httpClient.SendAsync(requestDel);

        if (response.IsSuccessStatusCode)
        {
          return new DeleteLocationRequest.Response(true);
        }
        else
        {
          // если запрос не выполнен
          return new DeleteLocationRequest.Response(false);
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
