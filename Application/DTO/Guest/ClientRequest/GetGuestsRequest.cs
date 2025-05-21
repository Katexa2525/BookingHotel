using MediatR;

namespace Application.DTO.Guest.ClientRequest
{
  public record GetGuestsRequest : IRequest<GetGuestsRequest.Response>
  {
    public const string RouteTemplate = "api/guests";

    public record Response(List<GuestAllDto>? Guests);
  }
}
