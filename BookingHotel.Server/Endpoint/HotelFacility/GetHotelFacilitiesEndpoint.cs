using Application.DTO.Hotel.ClientRequest;
using Application.DTO.HotelFacility.ClientRequest;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.HotelFacility
{
  public class GetHotelFacilitiesEndpoint : BaseAsyncEndpoint.WithRequest<Guid>.WithResponse<GetHotelFacilitiesRequest.Response>
  {
    private readonly IMediator _mediator;

    public GetHotelFacilitiesEndpoint(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet("api/hotels/{hotelId}/facilities/v3")]
    public override async Task<ActionResult<GetHotelFacilitiesRequest.Response>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
    {
      throw new NotImplementedException();
    }
  }
}
