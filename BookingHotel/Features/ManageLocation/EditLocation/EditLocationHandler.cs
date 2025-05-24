using Application.DTO.Location.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageLocation.EditLocation
{
  public class EditLocationHandler : IRequestHandler<EditLocationRequest, EditLocationRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public EditLocationHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<EditLocationRequest.Response> Handle(EditLocationRequest request, CancellationToken cancellationToken)
    {
      HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");

      //Получаю обновленные и отправляю их в API через HTTP - запрос методом PUT
      var response = await httpClient.PutAsJsonAsync(EditLocationRequest.RouteTemplate, request, cancellationToken);
      if (response.IsSuccessStatusCode)
      {
        //Если запрос был успешным, вызывающей стороне отправляется ответ true
        return new EditLocationRequest.Response(true);
      }
      else
      {
        return new EditLocationRequest.Response(false);
      }
    }
  }
}
