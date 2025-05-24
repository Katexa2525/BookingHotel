using Application.DTO.Location.ClientRequest;
using Application.DTO.Location.CQRS;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.Location
{
  public class AddLocationEndpoint : BaseAsyncEndpoint.WithRequest<AddLocationRequest>.WithResponse<Guid>
  {
    private readonly IMediator _mediator;

    public AddLocationEndpoint(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost(AddLocationRequest.RouteTemplate)]
    public override async Task<ActionResult<Guid>> HandleAsync(AddLocationRequest request, CancellationToken cancellationToken = default)
    {
      var result = await _mediator.Send(new CreateLocationCommand() { Dto = request.Location });
      return Ok(result);
    }
  }
}
