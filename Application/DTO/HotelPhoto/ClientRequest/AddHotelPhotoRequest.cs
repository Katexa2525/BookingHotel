using MediatR;

namespace Application.DTO.HotelPhoto.ClientRequest
{
  public record AddHotelPhotoRequest(HotelPhotoCreateWithIdDto HotelPhoto) : IRequest<AddHotelPhotoRequest.Response>
  {
    public const string RouteTemplate = "api/hotelphotos/create";

    public record Response(Guid hotelPhotoId);
  }
}
