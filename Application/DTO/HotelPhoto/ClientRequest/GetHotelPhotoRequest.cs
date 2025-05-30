using MediatR;

namespace Application.DTO.HotelPhoto.ClientRequest
{
  public record GetHotelPhotoRequest(Guid photoId) : IRequest<GetHotelPhotoRequest.Response>
  {
    public const string RouteTemplate = "/api/hotelphotos/{photoId}";

    public record Response(HotelPhotoDto? RoomPhoto);
  }
}
