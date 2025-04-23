using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Controllers
{
  [ApiController]
  [Route("roomtype")]
  public class RoomTypeController
  {
    private readonly IMediator _mediator;
    public RoomTypeController(IMediator mediator)
    {
      _mediator = mediator;
    }
  }
}
