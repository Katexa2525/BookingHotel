using Application.DTO.RoomFacility.ClientRequest;
using Application.DTO.RoomFacility.CQRS;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.RoomFacility
{
  public class AddRoomFacilityEndpoint : BaseAsyncEndpoint.WithRequest<AddRoomFacilityRequest>.WithResponse<Guid>
  {
    private readonly IMediator _mediator;

    public AddRoomFacilityEndpoint(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost(AddRoomFacilityRequest.RouteTemplate)]
    public override async Task<ActionResult<Guid>> HandleAsync(AddRoomFacilityRequest request, CancellationToken cancellationToken = default)
    {
      var result = await _mediator.Send(new CreateRoomFacilityCommand() { Dto = request.RoomFacility });
      return Ok(result);
    }
  }
}
