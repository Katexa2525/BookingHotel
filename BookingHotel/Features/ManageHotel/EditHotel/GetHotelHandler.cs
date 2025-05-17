using Application.DTO.Hotel;
using Application.DTO.Hotel.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageHotel.EditHotel
{
  public class GetHotelHandler : IRequestHandler<GetHotelRequest, GetHotelRequest.Response?>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public GetHotelHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<GetHotelRequest.Response?> Handle(GetHotelRequest request, CancellationToken cancellationToken)
    {
      try
      {
        // Незащищенный HttpClient используется для вызова API с использованием шаблона маршрута, который определили для запроса
        HttpClient? httpClient = _httpClientFactory.CreateClient("NoAuthenticationClient");

        //Заполнитель hotelId в RouteTemplate заменяется идентификатором отеля, подлежащему редактированию, перед выполнением HTTP-запроса
        string route = GetHotelRequest.RouteTemplate.Replace("{hotelId}", request.hotelId.ToString());

        var res = await httpClient.GetFromJsonAsync<HotelDto?>(route, cancellationToken);

        return new GetHotelRequest.Response(res);
      }
      catch (HttpRequestException ex)
      {
        Console.WriteLine(ex.Message);
        return default!;
      }
    }
  }
}
