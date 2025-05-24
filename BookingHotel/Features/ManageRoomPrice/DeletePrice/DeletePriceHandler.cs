using Application.DTO.Price.ClientRequest;
using MediatR;

namespace BookingHotel.Features.ManageRoomPrice.DeletePrice
{
  public class DeletePriceHandler : IRequestHandler<DeletePriceRequest, DeletePriceRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public DeletePriceHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<DeletePriceRequest.Response> Handle(DeletePriceRequest request, CancellationToken cancellationToken)
    {
      try
      {
        // Защищенный HttpClient используется для вызова API с использованием шаблона маршрута, который определили для запроса
        HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");
        //Заполнитель priceId в RouteTemplate заменяется идентификатором, подлежащему редактированию, перед выполнением HTTP-запроса
        string route = DeletePriceRequest.RouteTemplate.Replace("{priceId}", request.priceId.ToString());

        var requestDel = new HttpRequestMessage(HttpMethod.Delete, route);

        var response = await httpClient.SendAsync(requestDel);

        if (response.IsSuccessStatusCode)
        {
          return new DeletePriceRequest.Response(true);
        }
        else
        {
          // если запрос не выполнен
          return new DeletePriceRequest.Response(false);
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
