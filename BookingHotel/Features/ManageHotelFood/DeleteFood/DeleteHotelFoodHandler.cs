using Application.DTO.Food.ClientRequest;
using MediatR;

namespace BookingHotel.Features.ManageHotelFood.DeleteFood
{
  public class DeleteHotelFoodHandler : IRequestHandler<DeleteFoodRequest, DeleteFoodRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public DeleteHotelFoodHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<DeleteFoodRequest.Response> Handle(DeleteFoodRequest request, CancellationToken cancellationToken)
    {
      try
      {
        // Защищенный HttpClient используется для вызова API с использованием шаблона маршрута, который определили для запроса
        HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");
        //Заполнитель facilityId в RouteTemplate заменяется идентификатором удобства отеля, подлежащему редактированию, перед выполнением HTTP-запроса
        string route = DeleteFoodRequest.RouteTemplate.Replace("{foodId}", request.foodId.ToString());

        var requestDel = new HttpRequestMessage(HttpMethod.Delete, route);

        var response = await httpClient.SendAsync(requestDel);

        if (response.IsSuccessStatusCode)
        {
          return new DeleteFoodRequest.Response(true);
        }
        else
        {
          // если запрос не выполнен
          return new DeleteFoodRequest.Response(false);
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
