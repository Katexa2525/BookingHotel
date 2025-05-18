using Application.DTO.Room.ClientRequest;
using Application.DTO.Room.CQRS;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.Room
{
  public class AddRoomEndpoint : BaseAsyncEndpoint.WithRequest<AddRoomRequest>.WithResponse<Guid>
  {
    private readonly IMediator _mediator;

    public AddRoomEndpoint(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost(AddRoomRequest.RouteTemplate)]
    public override async Task<ActionResult<Guid>> HandleAsync(AddRoomRequest request, CancellationToken cancellationToken = default)
    {
      var result = await _mediator.Send(new CreateRoomCommand() { Dto = request.Room });
      return Ok(result);
    }
  }
}
