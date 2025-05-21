using MediatR;

namespace Application.DTO.Guest.ClientRequest
{
  public record EditGuestRequest(GuestDto guest) : IRequest<EditGuestRequest.Response>
  {
    public const string RouteTemplate = "api/guests/edit";
    public record Response(bool IsSuccess);
  }
}
