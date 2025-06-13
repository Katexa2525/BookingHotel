using Application.DTO.Guest.ClientRequest;
using Application.DTO.Guest.CQRS;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.Guest
{
  public class AddGuestEndpoint : BaseAsyncEndpoint.WithRequest<AddGuestRequest>.WithResponse<Guid>
  {
    private readonly IMediator _mediator;

    public AddGuestEndpoint(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost(AddGuestRequest.RouteTemplate)]
    public override async Task<ActionResult<Guid>> HandleAsync(AddGuestRequest request, CancellationToken cancellationToken = default)
    {
      var result = await _mediator.Send(new CreateGuestCommand() { Dto = request.Guest });
      return Ok(result);
    }
  }
}
