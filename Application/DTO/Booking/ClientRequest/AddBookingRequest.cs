using MediatR;

namespace Application.DTO.Booking.ClientRequest
{
  public record AddBookingRequest(BookingCreateDto Booking) : IRequest<AddBookingRequest.Response>
  {
    /// <summary>Адрес конечной точки</summary>
    public const string RouteTemplate = "api/bookings/create";

    /// <summary>Вложенная запись определяет данные ответа на запрос</summary>
    public record Response(Guid bookingId);
  }
}
