using Application.DTO.RoomType;
using Application.DTO.RoomType.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Controllers
{
  [ApiController]
  [Route("api/roomtypes")]
  public class RoomTypeController : ControllerBase
  {
    private readonly IMediator _mediator;

    public RoomTypeController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<RoomTypeAllDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
      var result = await _mediator.Send(new GetAllRoomTypeQuery() { });
      return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(RoomTypeDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
      var result = await _mediator.Send(new GetByIdRoomTypeQuery() { Id = id });
      return Ok(result);
    }
  }
}
