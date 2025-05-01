using Application.DTO.Hotel.ClientRequest;
using MediatR;

namespace BookingHotel.Features.ManageHotel.Mediatr
{
  public class UploadHotelImageHandler : IRequestHandler<UploadHotelImageRequest, UploadHotelImageRequest.Response>
  {
    private readonly HttpClient _httpClient;

    public UploadHotelImageHandler(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<UploadHotelImageRequest.Response> Handle(UploadHotelImageRequest request, CancellationToken cancellationToken)
    {
      var fileContent = request.File.OpenReadStream(request.File.Size, cancellationToken);

        using var content = new MultipartFormDataContent();
        content.Add(new StreamContent(fileContent), "image", request.File.Name);

        var response = await _httpClient.PostAsync(UploadHotelImageRequest.RouteTemplate.Replace("{hotelId}", request.HotelId.ToString()), content, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            var fileName = await response.Content.ReadAsStringAsync(cancellationToken: cancellationToken);
            return new UploadHotelImageRequest.Response(fileName);
        }
        else
        {
            return new UploadHotelImageRequest.Response("");
        }
    }
  }
}
