using Application.DTO.Hotel.ClientRequest;
using Application.DTO.HotelFacility.ClientRequest;
using MediatR;

namespace BookingHotel.Features.ManageHotelFacility.DeleteFacility
{
  public class DeleteHotelFacilityHandler : IRequestHandler<DeleteHotelFacilityRequest, DeleteHotelFacilityRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public DeleteHotelFacilityHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<DeleteHotelFacilityRequest.Response> Handle(DeleteHotelFacilityRequest request, CancellationToken cancellationToken)
    {
      try
      {
        // Защищенный HttpClient используется для вызова API с использованием шаблона маршрута, который определили для запроса
        HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");
        //Заполнитель facilityId в RouteTemplate заменяется идентификатором удобства отеля, подлежащему редактированию, перед выполнением HTTP-запроса
        string route = DeleteHotelFacilityRequest.RouteTemplate.Replace("{facilityId}", request.facilityId.ToString());

        var requestDel = new HttpRequestMessage(HttpMethod.Delete, route);

        var response = await httpClient.SendAsync(requestDel);

        if (response.IsSuccessStatusCode)
        {
          return new DeleteHotelFacilityRequest.Response(true);
        }
        else
        {
          // если запрос не выполнен
          return new DeleteHotelFacilityRequest.Response(false);
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
