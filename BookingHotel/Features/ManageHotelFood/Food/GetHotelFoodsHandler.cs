using Application.DTO.Food;
using Application.DTO.Food.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageHotelFood.Food
{
  public class GetHotelFoodsHandler : IRequestHandler<GetFoodsRequest, GetFoodsRequest.Response?>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public GetHotelFoodsHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<GetFoodsRequest.Response?> Handle(GetFoodsRequest request, CancellationToken cancellationToken)
    {
      try
      {
        HttpClient? httpClient = _httpClientFactory.CreateClient("NoAuthenticationClient");

        //Заполнитель hotelId в RouteTemplate заменяется идентификатором отеля, подлежащему редактированию, перед выполнением HTTP-запроса
        string route = GetFoodsRequest.RouteTemplate.Replace("{hotelId}", request.hotelId.ToString());

        // Выполняется запрос к API. В случае успеха ответ десериализуется и возвращается вызывающей стороне
        var allFoods = await httpClient.GetFromJsonAsync<List<FoodDto>>(route, cancellationToken);
        if (allFoods == null)
          return new GetFoodsRequest.Response(new List<FoodDto>());
        else
          return new GetFoodsRequest.Response(allFoods);
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
