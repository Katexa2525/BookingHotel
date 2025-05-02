using Application.DTO.Hotel.ClientRequest;
using Application.DTO.Hotel.CQRS;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.Hotel
{
  /// <summary> Класс конечной точки для создания записи по новому отелю </summary>
  public class AddHotelEndpoint : BaseAsyncEndpoint.WithRequest<AddHotelRequest>.WithResponse<int>
  {
    private readonly IMediator _mediator;

    public AddHotelEndpoint(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost(AddHotelRequest.RouteTemplate)]
    public override async Task<ActionResult<int>> HandleAsync(AddHotelRequest request, CancellationToken cancellationToken = default)
    {
      //throw new NotImplementedException();
      var result = await _mediator.Send(new CreateHotelCommand() { Dto = request.Hotel /*dto*/ });
      return Ok(result);
    }
  }
}
