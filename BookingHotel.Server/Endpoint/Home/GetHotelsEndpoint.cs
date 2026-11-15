using Application.DTO.Hotel;
using Application.DTO.Hotel.CQRS;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.Home
{
  public class GetHotelsEndpoint : BaseAsyncEndpoint.WithRequest<Guid>.WithResponse<HotelListPageDto>
  {
    private readonly IMediator _mediator;

    public GetHotelsEndpoint(IMediator mediator)
    {
      _mediator = mediator;
    }

    //[HttpGet(GetHotelsRequest.RouteTemplate)]
    [HttpGet("/api/hotels/v3")]
    public override async Task<ActionResult<HotelListPageDto>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
    {
      var hotels = await _mediator.Send(new GetAllHotelQuery(), cancellationToken);
      return Ok(hotels);
    }
  }
}
