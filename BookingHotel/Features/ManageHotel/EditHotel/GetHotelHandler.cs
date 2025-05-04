using Application.DTO.Hotel.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageHotel.EditHotel
{
  public class GetHotelHandler : IRequestHandler<GetHotelRequest, GetHotelRequest.Response?>
  {
    private readonly HttpClient _httpClient;

    public GetHotelHandler(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<GetHotelRequest.Response?> Handle(GetHotelRequest request, CancellationToken cancellationToken)
    {
      //var rep = GetHotelRequest.RouteTemplate.Replace("{hotelId}", request.hotelId.ToString());
      try
      {
        Console.WriteLine($"------- START GetHotelHandler Handle HotelId={request.hotelId} -------");

        var res = _httpClient.GetFromJsonAsync<GetHotelRequest.Response>(GetHotelRequest.RouteTemplate.Replace("{hotelId}",
                                                                            request.hotelId.ToString()),
                                                                            cancellationToken);

        Console.WriteLine($"------- GetHotelHandler Handle res={res.Status} -------");

        //Заполнитель hotelId в RouteTemplate заменяется идентификатором отеля, подлежащему редактированию, перед выполнением HTTP-запроса
        return await _httpClient.GetFromJsonAsync<GetHotelRequest.Response>(GetHotelRequest.RouteTemplate.Replace("{hotelId}", 
                                                                            request.hotelId.ToString()),
                                                                            cancellationToken);
      }
      catch (HttpRequestException ex)
      {
        Console.WriteLine(ex.Message);
        return default!;
      }
    }
  }
}
