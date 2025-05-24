using Application.DTO.HotelFacility.CQRS;
using Application.DTO.HotelFacility;
using Application.DTO.Room;
using Application.DTO.Room.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.DTO.RoomFacility;
using Application.DTO.RoomFacility.CQRS;

namespace BookingHotel.Server.Controllers
{
  [ApiController]
  [Route("api/rooms")]
  public class RoomController : ControllerBase
  {
    private readonly IMediator _mediator;
    public RoomController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<RoomAllDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
      var result = await _mediator.Send(new GetAllRoomQuery() { });
      return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] RoomCreateDto dto)
    {
      var result = await _mediator.Send(new CreateRoomCommand() { Dto = dto });
      return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update([FromBody] RoomUpdateDto dto)
    {
      await _mediator.Send(new UpdateRoomCommand { Dto = dto });
      return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id)
    {
      var result = await _mediator.Send(new DeleteRoomCommand { RoomId = id });
      return NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(RoomDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
      var result = await _mediator.Send(new GetByIdRoomQuery() { Id = id });
      return Ok(result);
    }

    [HttpGet]
    [Route("{roomid}/facilities")]
    [ProducesResponseType(typeof(List<RoomFacilityDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<RoomFacilityDto>>> GetFacilitiesByHotelId([FromRoute] Guid roomid)
    {
      var result = await _mediator.Send(new GetAllRoomFacilityByRoomIdQuery() { RoomId = roomid });
      return Ok(result);
    }
  }
}
