using Application.ConstMessages;
using Application.DTO.Hotel.ClientRequest;
using Application.DTO.Hotel.CQRS;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.Home
{
  public class GetHotelsEndpoint : BaseAsyncEndpoint.WithRequest<Guid>.WithResponse<GetHotelsRequest.Response>
  {
    private readonly IMediator _mediator;

    public GetHotelsEndpoint(IMediator mediator)
    {
      _mediator = mediator;
    }

    //[HttpGet(GetHotelsRequest.RouteTemplate)]
    [HttpGet("/api/hotels/v3")]
    public override async Task<ActionResult<GetHotelsRequest.Response>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
    {

      // получаю все отели из БД
      var hotels = await _mediator.Send(new GetAllHotelQuery());
      if (hotels is null)
      {
        return BadRequest(AppMessage.GetHotelAllTextErrorMessage);
      }

      //Если отель найден, возвращается новый экземпляр GetHotelRequest.Response, содержащий сведения о нём
      //var response = new GetHotelsRequest.Response(
      //  hotels.Select(hotel => new GetHotelsRequest.AllHotel(
      //    hotel.Id, hotel.Name, hotel.Description, hotel.Location, hotel.Rating, hotel.Star, hotel.MainPhoto
      //    ))
      //  );

      //return Ok(response);
      return Ok(hotels);

    }
  }
}
