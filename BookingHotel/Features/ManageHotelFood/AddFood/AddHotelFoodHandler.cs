using Application.DTO.Food.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageHotelFood.AddFood
{
  public class AddHotelFoodHandler : IRequestHandler<AddFoodRequest, AddFoodRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public AddHotelFoodHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<AddFoodRequest.Response> Handle(AddFoodRequest request, CancellationToken cancellationToken)
    {
      try
      {
        // Защищенный HttpClient используется для вызова API с использованием шаблона маршрута, который определили для запроса
        HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");
        //httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        var response = await httpClient.PostAsJsonAsync(AddFoodRequest.RouteTemplate, request, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
          Guid hotelFoodId = await response.Content.ReadFromJsonAsync<Guid>(cancellationToken);
          // если запрос был успешным, то hotelId считывается из ответа и возвращается с помощью записи AddHotelRequest.Response
          return new AddFoodRequest.Response(hotelFoodId);
        }
        else
        {
          // если запрос не выполнен
          return new AddFoodRequest.Response(Guid.Empty);
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
