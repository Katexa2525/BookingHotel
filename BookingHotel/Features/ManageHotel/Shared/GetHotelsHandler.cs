using Application.DTO.Hotel.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageHotel.Shared
{
  public class GetHotelsHandler : IRequestHandler<GetHotelsRequest, GetHotelsRequest.Response?>
  {
    private readonly HttpClient _httpClient;

    public GetHotelsHandler(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<GetHotelsRequest.Response?> Handle(GetHotelsRequest request, CancellationToken cancellationToken)
    {
      try
      {
        // Выполняется запрос к API. В случае успеха ответ десериализуется и возвращается вызывающей стороне
        return await _httpClient.GetFromJsonAsync<GetHotelsRequest.Response>(GetHotelsRequest.RouteTemplate);
      }
      catch (HttpRequestException) 
      {
        //В противном случае вызывающая сторона получает в качестве ответа null
        return default!;
      }
    }
  }
}
