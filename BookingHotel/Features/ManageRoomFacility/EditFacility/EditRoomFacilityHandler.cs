using Application.DTO.RoomFacility.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageRoomFacility.EditFacility
{
  public class EditRoomFacilityHandler : IRequestHandler<EditRoomFacilityRequest, EditRoomFacilityRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public EditRoomFacilityHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<EditRoomFacilityRequest.Response> Handle(EditRoomFacilityRequest request, CancellationToken cancellationToken)
    {
      HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");

      //Получаю обновленные сведения об отеле и отправляю их в API через HTTP - запрос методом PUT
      var response = await httpClient.PutAsJsonAsync(EditRoomFacilityRequest.RouteTemplate, request, cancellationToken);
      if (response.IsSuccessStatusCode)
      {
        //Если запрос был успешным, вызывающей стороне отправляется ответ true
        return new EditRoomFacilityRequest.Response(true);
      }
      else
      {
        return new EditRoomFacilityRequest.Response(false);
      }
    }
  }
}
