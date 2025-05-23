using Application.DTO.HotelFacility.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageHotelFacility.EditFacility
{
  public class EditHotelFacilityHandler : IRequestHandler<EditHotelFacilityRequest, EditHotelFacilityRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public EditHotelFacilityHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<EditHotelFacilityRequest.Response> Handle(EditHotelFacilityRequest request, CancellationToken cancellationToken)
    {
      HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");

      //Получаю обновленные сведения об отеле и отправляю их в API через HTTP - запрос методом PUT
      var response = await httpClient.PutAsJsonAsync(EditHotelFacilityRequest.RouteTemplate, request, cancellationToken);
      if (response.IsSuccessStatusCode)
      {
        //Если запрос был успешным, вызывающей стороне отправляется ответ true
        return new EditHotelFacilityRequest.Response(true);
      }
      else
      {
        return new EditHotelFacilityRequest.Response(false);
      }
    }
  }
}
