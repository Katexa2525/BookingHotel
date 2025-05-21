using Application.DTO.Booking.ClientRequest;
using Application.DTO.Booking.CQRS;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.Booking
{
  public class AddBookingEndpoint : BaseAsyncEndpoint.WithRequest<AddBookingRequest>.WithResponse<Guid>
  {
    private readonly IMediator _mediator;

    public AddBookingEndpoint(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost(AddBookingRequest.RouteTemplate)]
    public override async Task<ActionResult<Guid>> HandleAsync(AddBookingRequest request, CancellationToken cancellationToken = default)
    {
      var result = await _mediator.Send(new CreateBookingCommand() { Dto = request.Booking });
      return Ok(result);
    }
  }
}
