using Application.DTO.Location;
using Application.DTO.Location.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageLocation.Location
{
  public class GetLocationsHandler : IRequestHandler<GetLocationsRequest, GetLocationsRequest.Response?>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public GetLocationsHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<GetLocationsRequest.Response?> Handle(GetLocationsRequest request, CancellationToken cancellationToken)
    {
      try
      {
        HttpClient? httpClient = _httpClientFactory.CreateClient("NoAuthenticationClient");

        //Заполнитель hotelId в RouteTemplate заменяется идентификатором отеля, подлежащему редактированию, перед выполнением HTTP-запроса
        string route = GetLocationsRequest.RouteTemplate.Replace("{hotelId}", request.hotelId.ToString());

        // Выполняется запрос к API. В случае успеха ответ десериализуется и возвращается вызывающей стороне
        var allLocations = await httpClient.GetFromJsonAsync<List<LocationDto>>(route, cancellationToken);
        if (allLocations == null)
          return new GetLocationsRequest.Response(new List<LocationDto>());
        else
          return new GetLocationsRequest.Response(allLocations);
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
