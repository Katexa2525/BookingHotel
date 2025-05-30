using Application.DTO.HotelPhoto.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageHotelPhoto.EditPhoto
{
  public class EditHotelPhotoHandler : IRequestHandler<EditHotelPhotoRequest, EditHotelPhotoRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public EditHotelPhotoHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<EditHotelPhotoRequest.Response> Handle(EditHotelPhotoRequest request, CancellationToken cancellationToken)
    {
      HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");

      var response = await httpClient.PutAsJsonAsync(EditHotelPhotoRequest.RouteTemplate, request, cancellationToken);
      if (response.IsSuccessStatusCode)
      {
        //Если запрос был успешным, вызывающей стороне отправляется ответ true
        return new EditHotelPhotoRequest.Response(true);
      }
      else
      {
        return new EditHotelPhotoRequest.Response(false);
      }
    }
  }
}
