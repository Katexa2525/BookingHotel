using Application.DTO.Hotel.ClientRequest;
using MediatR;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace BookingHotel.Features.ManageHotel.Mediatr
{
  /// <summary>Класс обработчика запросов по отелям</summary>
  public class AddHotelHandler : IRequestHandler<AddHotelRequest, AddHotelRequest.Response>
  {
    private readonly HttpClient _httpClient;
    private readonly IHttpClientFactory _clientFactory;

    public AddHotelHandler(HttpClient httpClient, IHttpClientFactory clientFactory)
    {
      _httpClient = httpClient;
      _clientFactory = clientFactory;
    }

    /// <summary>Метод для обработки запроса Mediatr </summary>
    /// <param name="request">Запрос</param>
    /// <param name="cancellationToken">Токен отмены запроса</param>
    /// <returns></returns> 
    public async Task<AddHotelRequest.Response> Handle(AddHotelRequest request, CancellationToken cancellationToken)
    {
      // HttpClient используется для вызова API с использованием шаблона маршрута, который определили для запроса
      //var response = await _httpClient.PostAsJsonAsync(AddHotelRequest.RouteTemplate, request, cancellationToken);

      // Защищенный HttpClient используется для вызова API с использованием шаблона маршрута, который определили для запроса
      HttpClient? client = _clientFactory.CreateClient("SecureAPIClient");
      client.DefaultRequestHeaders.Add("Accept", "application/json");
      var response = await client.PostAsJsonAsync(AddHotelRequest.RouteTemplate, request, cancellationToken);

      if (response.IsSuccessStatusCode)
      {
        //int hotelId = await response.Content.ReadFromJsonAsync<int>(cancellationToken);
        Guid hotelId = await response.Content.ReadFromJsonAsync<Guid>(cancellationToken);
        // если запрос был успешным, то hotelId считывается из ответа и возвращается с помощью записи AddHotelRequest.Response
        return new AddHotelRequest.Response(hotelId);
      }
      else
      {
        // если запрос не выполнен
        return new AddHotelRequest.Response(Guid.Empty);
      }
    }
  }
}
