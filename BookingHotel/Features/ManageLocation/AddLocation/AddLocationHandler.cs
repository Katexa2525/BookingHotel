using Application.DTO.Location.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageLocation.AddLocation
{
  public class AddLocationHandler : IRequestHandler<AddLocationRequest, AddLocationRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public AddLocationHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<AddLocationRequest.Response> Handle(AddLocationRequest request, CancellationToken cancellationToken)
    {
      try
      {
        // Защищенный HttpClient используется для вызова API с использованием шаблона маршрута, который определили для запроса
        HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");
        //httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        var response = await httpClient.PostAsJsonAsync(AddLocationRequest.RouteTemplate, request, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
          Guid locationId = await response.Content.ReadFromJsonAsync<Guid>(cancellationToken);
          // если запрос был успешным, то hotelId считывается из ответа и возвращается с помощью записи AddHotelRequest.Response
          return new AddLocationRequest.Response(locationId);
        }
        else
        {
          // если запрос не выполнен
          return new AddLocationRequest.Response(Guid.Empty);
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
