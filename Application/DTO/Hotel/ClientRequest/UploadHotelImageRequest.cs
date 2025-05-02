using MediatR;
using Microsoft.AspNetCore.Components.Forms;

namespace Application.DTO.Hotel.ClientRequest
{
  public record UploadHotelImageRequest(Guid HotelId, IBrowserFile File) : IRequest<UploadHotelImageRequest.Response>
  {
    public const string RouteTemplate = "/api/hotels/{hotelId}/images";

    public record Response(string ImageName);
  }
}
