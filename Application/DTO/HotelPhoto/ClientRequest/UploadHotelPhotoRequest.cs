using MediatR;
using Microsoft.AspNetCore.Components.Forms;

namespace Application.DTO.HotelPhoto.ClientRequest
{
  public record UploadHotelPhotoRequest(Guid HotelId, IBrowserFile File) : IRequest<UploadHotelPhotoRequest.Response>
  {
    public const string RouteTemplate = "/api/hotels/{hotelId}/images";

    public record Response(string ImageName);
  }
}
