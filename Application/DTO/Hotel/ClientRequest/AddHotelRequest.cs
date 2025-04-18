using Application.DTO.Hotel;
using MediatR;

namespace Application.DTO.Hotel.ClientRequest
{
  /// <summary> Модель запроса с клиента по добавлению отеля </summary>
  /// <param name="Hotel"></param>
  public record AddHotelRequest(HotelCreateDto Hotel) : IRequest<AddHotelRequest.Response>
  {
    /// <summary>Адрес конечной точки</summary>
    public const string RouteTemplate = "api/hotels/create";
    /// <summary>Вложенная запись определяет данные ответа на запрос</summary>
    /// <param name="hotelId">Guid отеля</param>
    public record Response(Guid hotelId);
  }
}
