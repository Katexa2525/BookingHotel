using MediatR;

namespace Application.DTO.Guest.ClientRequest
{
  public record AddGuestRequest(GuestCreateDto Guest) : IRequest<AddGuestRequest.Response>
  {
    /// <summary>Адрес конечной точки</summary>
    public const string RouteTemplate = "api/guests/create";

    /// <summary>Вложенная запись определяет данные ответа на запрос</summary>
    public record Response(Guid guestId);
  }
}
