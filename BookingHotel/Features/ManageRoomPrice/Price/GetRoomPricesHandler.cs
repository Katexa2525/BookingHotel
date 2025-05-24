using Application.DTO.Price;
using Application.DTO.Price.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageRoomPrice.Price
{
  public class GetRoomPricesHandler : IRequestHandler<GetPricesRequest, GetPricesRequest.Response?>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public GetRoomPricesHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<GetPricesRequest.Response?> Handle(GetPricesRequest request, CancellationToken cancellationToken)
    {
      try
      {
        HttpClient? httpClient = _httpClientFactory.CreateClient("NoAuthenticationClient");

        //Заполнитель roomId в RouteTemplate заменяется идентификатором отеля, подлежащему редактированию, перед выполнением HTTP-запроса
        string route = GetPricesRequest.RouteTemplate.Replace("{roomId}", request.roomId.ToString());

        // Выполняется запрос к API. В случае успеха ответ десериализуется и возвращается вызывающей стороне
        var allPrices = await httpClient.GetFromJsonAsync<List<PriceDto>>(route, cancellationToken);
        if (allPrices == null)
          return new GetPricesRequest.Response(new List<PriceDto>());
        else
          return new GetPricesRequest.Response(allPrices);

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
