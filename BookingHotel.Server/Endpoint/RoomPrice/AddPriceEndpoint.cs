using Application.DTO.Price.ClientRequest;
using Application.DTO.Price.CQRS;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.RoomPrice
{
  public class AddPriceEndpoint : BaseAsyncEndpoint.WithRequest<AddPriceRequest>.WithResponse<Guid>
  {
    private readonly IMediator _mediator;

    public AddPriceEndpoint(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost(AddPriceRequest.RouteTemplate)]
    public override async Task<ActionResult<Guid>> HandleAsync(AddPriceRequest request, CancellationToken cancellationToken = default)
    {
      var result = await _mediator.Send(new CreatePriceCommand() { Dto = request.Price });
      return Ok(result);
    }
  }
}
