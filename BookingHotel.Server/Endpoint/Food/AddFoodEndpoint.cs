using Application.DTO.Food.ClientRequest;
using Application.DTO.Food.CQRS;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.Food
{
  public class AddFoodEndpoint : BaseAsyncEndpoint.WithRequest<AddFoodRequest>.WithResponse<Guid>
  {
    private readonly IMediator _mediator;

    public AddFoodEndpoint(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost(AddFoodRequest.RouteTemplate)]
    public override async Task<ActionResult<Guid>> HandleAsync(AddFoodRequest request, CancellationToken cancellationToken = default)
    {
      var result = await _mediator.Send(new CreateFoodCommand() { Dto = request.Food });
      return Ok(result);
    }
  }
}
