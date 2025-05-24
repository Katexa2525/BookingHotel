using Application.DTO.Price.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageRoomPrice.EditPrice
{
  public class EditPriceHandler : IRequestHandler<EditPriceRequest, EditPriceRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public EditPriceHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<EditPriceRequest.Response> Handle(EditPriceRequest request, CancellationToken cancellationToken)
    {
      HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");

      //Получаю обновленные сведения об отеле и отправляю их в API через HTTP - запрос методом PUT
      var response = await httpClient.PutAsJsonAsync(EditPriceRequest.RouteTemplate, request, cancellationToken);
      if (response.IsSuccessStatusCode)
      {
        //Если запрос был успешным, вызывающей стороне отправляется ответ true
        return new EditPriceRequest.Response(true);
      }
      else
      {
        return new EditPriceRequest.Response(false);
      }
    }
  }
}
