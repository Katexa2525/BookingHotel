using Application.DTO.TypeFood;
using Application.DTO.TypeFood.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageTypeFood.TypeFood
{
  public class GetTypeFoodsHandler : IRequestHandler<GetTypeFoodsRequest, GetTypeFoodsRequest.Response?>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public GetTypeFoodsHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<GetTypeFoodsRequest.Response?> Handle(GetTypeFoodsRequest request, CancellationToken cancellationToken)
    {
      try
      {
        HttpClient? httpClient = _httpClientFactory.CreateClient("NoAuthenticationClient");

        // Выполняется запрос к API. В случае успеха ответ десериализуется и возвращается вызывающей стороне
        var allTypeFoods = await httpClient.GetFromJsonAsync<List<TypeFoodDto>>(GetTypeFoodsRequest.RouteTemplate, cancellationToken);
        return new GetTypeFoodsRequest.Response(allTypeFoods);
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
