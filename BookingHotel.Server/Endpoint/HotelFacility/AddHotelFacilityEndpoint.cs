using Application.DTO.HotelFacility.ClientRequest;
using Application.DTO.HotelFacility.CQRS;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.HotelFacility
{
  public class AddHotelFacilityEndpoint : BaseAsyncEndpoint.WithRequest<AddHotelFacilityRequest>.WithResponse<Guid>
  {
    private readonly IMediator _mediator;

    public AddHotelFacilityEndpoint(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost(AddHotelFacilityRequest.RouteTemplate)]
    public override async Task<ActionResult<Guid>> HandleAsync(AddHotelFacilityRequest request, CancellationToken cancellationToken = default)
    {
      var result = await _mediator.Send(new CreateHotelFacilityCommand() { Dto = request.HotelFacility });
      return Ok(result);
    }
  }
}
