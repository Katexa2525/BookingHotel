using Application.DTO.Room.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageRoom.EditRoom
{
  public class EditRoomHandler : IRequestHandler<EditRoomRequest, EditRoomRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public EditRoomHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<EditRoomRequest.Response> Handle(EditRoomRequest request, CancellationToken cancellationToken)
    {
      HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");

      //Получаю обновленные сведения об отеле и отправляю их в API через HTTP - запрос методом PUT
      var response = await httpClient.PutAsJsonAsync(EditRoomRequest.RouteTemplate, request, cancellationToken);
      if (response.IsSuccessStatusCode)
      {
        //Если запрос был успешным, вызывающей стороне отправляется ответ true
        return new EditRoomRequest.Response(true);
      }
      else
      {
        return new EditRoomRequest.Response(false);
      }
    }
  }
}
