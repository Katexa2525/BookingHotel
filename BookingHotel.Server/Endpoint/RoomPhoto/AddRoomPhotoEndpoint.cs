using Application.DTO.RoomPhoto.ClientRequest;
using Application.DTO.RoomPhoto.CQRS;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.RoomPhoto
{
  public class AddRoomPhotoEndpoint : BaseAsyncEndpoint.WithRequest<AddRoomPhotoRequest>.WithResponse<Guid>
  {
    private readonly IMediator _mediator;

    public AddRoomPhotoEndpoint(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost(AddRoomPhotoRequest.RouteTemplate)]
    public override async Task<ActionResult<Guid>> HandleAsync(AddRoomPhotoRequest request, CancellationToken cancellationToken = default)
    {
      var result = await _mediator.Send(new CreateRoomPhotoCommand() { Dto = request.RoomPhoto });
      return Ok(result);
    }
  }
}
