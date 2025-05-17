using MediatR;

namespace Application.DTO.Hotel.ClientRequest
{
  public record EditHotelRequest(HotelDto hotel) : IRequest<EditHotelRequest.Response>
  {
    //public const string RouteTemplate = "api/hotels";
    public const string RouteTemplate = "api/hotels/edit";
    public record Response(bool IsSuccess);
  }
}
