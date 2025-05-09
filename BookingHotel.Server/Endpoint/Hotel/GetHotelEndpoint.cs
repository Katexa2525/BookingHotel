using Application.ConstMessages;
using Application.DTO.Hotel.ClientRequest;
using Application.DTO.Hotel.CQRS;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookingHotel.Server.Endpoint.Hotel
{
  public class GetHotelEndpoint : BaseAsyncEndpoint.WithRequest<Guid>.WithResponse<GetHotelRequest.Response>
  {
    private readonly IMediator _mediator;

    public GetHotelEndpoint(IMediator mediator)
    {
      _mediator = mediator;
    }

    //[HttpGet(GetHotelRequest.RouteTemplate)]
    [HttpGet("/api/hotels/v3/{hotelId}")]
    public override async Task<ActionResult<GetHotelRequest.Response>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
    {
      // получаю отель из БД
      var hotel = await _mediator.Send(new GetByIdHotelQuery() { Id = request });
      if (hotel is null)
      {
        return BadRequest(AppMessage.GetHotelByIdTextErrorMessage);
      }
      // Если отель найден, возвращается новый экземпляр GetHotelRequest.Response, содержащий сведения о нём
      var response = new GetHotelRequest.Response(hotel);

      return Ok(response);
    }
  }
}
