using MediatR;

namespace Application.DTO.Guest.ClientRequest
{
  public record GetGuestRequest(Guid guestId) : IRequest<GetGuestRequest.Response>
  {
    public const string RouteTemplate = "/api/guests/{bookingId}";

    public record Response(GuestDto? Guest);
  }
}
