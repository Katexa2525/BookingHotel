using Application.DTO.RoomPhoto.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageRoomPhoto.EditPhoto
{
  public class EditRoomPhotoHandler : IRequestHandler<EditRoomPhotoRequest, EditRoomPhotoRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public EditRoomPhotoHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<EditRoomPhotoRequest.Response> Handle(EditRoomPhotoRequest request, CancellationToken cancellationToken)
    {
      HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");

      var response = await httpClient.PutAsJsonAsync(EditRoomPhotoRequest.RouteTemplate, request, cancellationToken);
      if (response.IsSuccessStatusCode)
      {
        //Если запрос был успешным, вызывающей стороне отправляется ответ true
        return new EditRoomPhotoRequest.Response(true);
      }
      else
      {
        return new EditRoomPhotoRequest.Response(false);
      }
    }
  }
}
