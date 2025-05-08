using Application.DTO.Hotel.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageHotel.Mediatr
{
  /// <summary>Класс обработчика запросов по отелям</summary>
  public class AddHotelHandler : IRequestHandler<AddHotelRequest, AddHotelRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public AddHotelHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    /// <summary>Метод для обработки запроса Mediatr </summary>
    /// <param name="request">Запрос</param>
    /// <param name="cancellationToken">Токен отмены запроса</param>
    /// <returns></returns> 
    public async Task<AddHotelRequest.Response> Handle(AddHotelRequest request, CancellationToken cancellationToken)
    {
      // Защищенный HttpClient используется для вызова API с использованием шаблона маршрута, который определили для запроса
      HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");
      httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
      var response = await httpClient.PostAsJsonAsync(AddHotelRequest.RouteTemplate, request, cancellationToken);

      if (response.IsSuccessStatusCode)
      {
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
