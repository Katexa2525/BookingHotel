using Application.DTO.HotelFacility;
using Application.DTO.HotelFacility.ClientRequest;
using Application.DTO.Room.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageHotelFacility.Facility
{
  public class GetHotelFacilitiesHandler : IRequestHandler<GetHotelFacilitiesRequest, GetHotelFacilitiesRequest.Response?>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public GetHotelFacilitiesHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<GetHotelFacilitiesRequest.Response?> Handle(GetHotelFacilitiesRequest request, CancellationToken cancellationToken)
    {
      try
      {
        HttpClient? httpClient = _httpClientFactory.CreateClient("NoAuthenticationClient");

        //Заполнитель hotelId в RouteTemplate заменяется идентификатором отеля, подлежащему редактированию, перед выполнением HTTP-запроса
        string route = GetHotelFacilitiesRequest.RouteTemplate.Replace("{hotelId}", request.hotelId.ToString());

        // Выполняется запрос к API. В случае успеха ответ десериализуется и возвращается вызывающей стороне
        var allFacilities = await httpClient.GetFromJsonAsync<List<HotelFacilityDto>>(route, cancellationToken);
        if (allFacilities == null)
          return new GetHotelFacilitiesRequest.Response( new List<HotelFacilityDto>());
        else
          return new GetHotelFacilitiesRequest.Response(allFacilities);
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
