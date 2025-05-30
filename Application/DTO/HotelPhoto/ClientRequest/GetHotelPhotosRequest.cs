using MediatR;

namespace Application.DTO.HotelPhoto.ClientRequest
{
  public record GetHotelPhotosRequest(Guid hotelId) : IRequest<GetHotelPhotosRequest.Response>
  {
    public const string RouteTemplate = "api/hotels/{hotelId}/photos";

    public record Response(List<HotelPhotoDto>? RoomPhotos);
  }
}
