using Application.DTO.Price.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageRoomPrice.AddPrice
{
  public class AddPriceHandler : IRequestHandler<AddPriceRequest, AddPriceRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public AddPriceHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<AddPriceRequest.Response> Handle(AddPriceRequest request, CancellationToken cancellationToken)
    {
      try
      {
        // Защищенный HttpClient используется для вызова API с использованием шаблона маршрута, который определили для запроса
        HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");
        //httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        var response = await httpClient.PostAsJsonAsync(AddPriceRequest.RouteTemplate, request, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
          Guid hotelFacilityId = await response.Content.ReadFromJsonAsync<Guid>(cancellationToken);
          // если запрос был успешным, то hotelId считывается из ответа и возвращается с помощью записи AddHotelRequest.Response
          return new AddPriceRequest.Response(hotelFacilityId);
        }
        else
        {
          // если запрос не выполнен
          return new AddPriceRequest.Response(Guid.Empty);
        }
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
