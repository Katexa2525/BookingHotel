using Application.DTO.RoomFacility.ClientRequest;
using MediatR;

namespace BookingHotel.Features.ManageRoomFacility.DeleteFacility
{
  public class DeleteRoomFacilityHandler : IRequestHandler<DeleteRoomFacilityRequest, DeleteRoomFacilityRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public DeleteRoomFacilityHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<DeleteRoomFacilityRequest.Response> Handle(DeleteRoomFacilityRequest request, CancellationToken cancellationToken)
    {
      try
      {
        // Защищенный HttpClient используется для вызова API с использованием шаблона маршрута, который определили для запроса
        HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");
        //Заполнитель facilityId в RouteTemplate заменяется идентификатором удобства отеля, подлежащему редактированию, перед выполнением HTTP-запроса
        string route = DeleteRoomFacilityRequest.RouteTemplate.Replace("{facilityId}", request.facilityId.ToString());

        var requestDel = new HttpRequestMessage(HttpMethod.Delete, route);

        var response = await httpClient.SendAsync(requestDel);

        if (response.IsSuccessStatusCode)
        {
          return new DeleteRoomFacilityRequest.Response(true);
        }
        else
        {
          // если запрос не выполнен
          return new DeleteRoomFacilityRequest.Response(false);
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
