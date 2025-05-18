using Application.DTO.RoomType;
using Application.DTO.RoomType.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageRoomType.RoomType
{
  public class GetRoomTypesHandler : IRequestHandler<GetRoomTypesRequest, GetRoomTypesRequest.Response?>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public GetRoomTypesHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<GetRoomTypesRequest.Response?> Handle(GetRoomTypesRequest request, CancellationToken cancellationToken)
    {
      try
      {
        HttpClient? httpClient = _httpClientFactory.CreateClient("NoAuthenticationClient");

        // Выполняется запрос к API. В случае успеха ответ десериализуется и возвращается вызывающей стороне
        var allRoomTypes = await httpClient.GetFromJsonAsync<List<RoomTypeAllDto>>(GetRoomTypesRequest.RouteTemplate, cancellationToken);
        return new GetRoomTypesRequest.Response(allRoomTypes);
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
