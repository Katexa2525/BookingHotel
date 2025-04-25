using Application.DTO.Hotel.ClientRequest;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint
{
  public class AddHotelEndpoint : BaseAsyncEndpoint.WithRequest<AddHotelRequest>.WithResponse<int>
  {
    private readonly IMediator _mediator;

    public AddHotelEndpoint(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost(AddHotelRequest.RouteTemplate)]
    public override Task<ActionResult<int>> HandleAsync(AddHotelRequest request, CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }
  }
}
