using MediatR;

namespace Application.DTO.HotelPhoto.ClientRequest
{
  public record EditHotelPhotoRequest(HotelPhotoDto hotelPhoto) : IRequest<EditHotelPhotoRequest.Response>
  {
    public const string RouteTemplate = "api/hotelphotos/edit";
    public record Response(bool IsSuccess);
  }
}
