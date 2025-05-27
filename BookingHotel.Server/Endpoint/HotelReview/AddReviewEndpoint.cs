using Application.DTO.Review.ClientRequest;
using Application.DTO.Review.CQRS;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.HotelReview
{
  public class AddReviewEndpoint : BaseAsyncEndpoint.WithRequest<AddReviewRequest>.WithResponse<Guid>
  {
    private readonly IMediator _mediator;

    public AddReviewEndpoint(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost(AddReviewRequest.RouteTemplate)]
    public async override Task<ActionResult<Guid>> HandleAsync(AddReviewRequest request, CancellationToken cancellationToken = default)
    {
      var result = await _mediator.Send(new CreateReviewCommand() { Dto = request.Review });
      return Ok(result);
    }
  }
}
