using Application.DTO.RoomFacility;
using Application.DTO.RoomFacility.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageRoomFacility.Facility
{
  public class GetRoomFacilitiesHandler : IRequestHandler<GetRoomFacilitiesRequest, GetRoomFacilitiesRequest.Response?>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public GetRoomFacilitiesHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<GetRoomFacilitiesRequest.Response?> Handle(GetRoomFacilitiesRequest request, CancellationToken cancellationToken)
    {
      try
      {
        HttpClient? httpClient = _httpClientFactory.CreateClient("NoAuthenticationClient");

        // Выполняется запрос к API. В случае успеха ответ десериализуется и возвращается вызывающей стороне
        var allFacilities = await httpClient.GetFromJsonAsync<List<RoomFacilityDto>>(GetRoomFacilitiesRequest.RouteTemplate, cancellationToken);
        return new GetRoomFacilitiesRequest.Response(allFacilities);

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
