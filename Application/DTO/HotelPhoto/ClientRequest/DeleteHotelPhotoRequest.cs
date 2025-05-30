using MediatR;

namespace Application.DTO.HotelPhoto.ClientRequest
{
  public record DeleteHotelPhotoRequest(Guid photoId) : IRequest<DeleteHotelPhotoRequest.Response>
  {
    public const string RouteTemplate = "api/hotelphotos/{photoId}";

    public record Response(bool IsSuccess);
  }
}
