using Application.DTO.Hotel;
using MediatR;

namespace BookingHotel.Features.ManageHotel.Mediatr
{
  public record AddHotelRequest(HotelDto Hotel) : IRequest<AddHotelRequest.Response>
  {
    /// <summary>Адрес конечной точки</summary>
    public const string RouteTemplate = "/api/hotels";
    /// <summary>Вложенная запись определяет данные ответа на запрос</summary>
    /// <param name="hotelId"></param>
    public record Response(int HotelId);
  }
}
