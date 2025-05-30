using Application.DTO.HotelPhoto.ClientRequest;
using Application.DTO.HotelPhoto.CQRS;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.HotelPhoto
{
  public class AddHotelPhotoEndpoint : BaseAsyncEndpoint.WithRequest<AddHotelPhotoRequest>.WithResponse<Guid>
  {
    private readonly IMediator _mediator;

    public AddHotelPhotoEndpoint(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost(AddHotelPhotoRequest.RouteTemplate)]
    public override async Task<ActionResult<Guid>> HandleAsync(AddHotelPhotoRequest request, CancellationToken cancellationToken = default)
    {
      var result = await _mediator.Send(new CreateHotelPhotoCommand() { Dto = request.HotelPhoto });
      return Ok(result);
    }
  }
}
