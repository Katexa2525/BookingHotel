using Application.DTO.Hotel.ClientRequest;
using MediatR;
using System.Net.Http;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageHotel.EditHotel
{
  public class EditHotelHandler : IRequestHandler<EditHotelRequest, EditHotelRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public EditHotelHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<EditHotelRequest.Response> Handle(EditHotelRequest request, CancellationToken cancellationToken)
    {
      HttpClient? httpClient = _httpClientFactory.CreateClient("NoAuthenticationClient");

      //Получаю обновленные сведения об отеле и отправляю их в API через HTTP - запрос методом PUT
      var response = await httpClient.PutAsJsonAsync(EditHotelRequest.RouteTemplate, request, cancellationToken);
      if (response.IsSuccessStatusCode)
      {
        //Если запрос был успешным, вызывающей стороне отправляется ответ true
        return new EditHotelRequest.Response(true);
      }
      else
      {
        return new EditHotelRequest.Response(false);
      }
    }
  }
}
