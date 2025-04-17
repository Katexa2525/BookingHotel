using Application.DTO.RoomFacility;
using Application.DTO.RoomFacility.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Controllers
{
  [ApiController]
  [Route("roomFacility")]
  public class RoomFacilityController : ControllerBase
  {
    private readonly IMediator _mediator;
    public RoomFacilityController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<RoomFacilityDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
      var result = await _mediator.Send(new GetAllRoomFacilityQuery() { });
      return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] RoomFacilityCreateWithIdDto dto)
    {
      var result = await _mediator.Send(new CreateRoomFacilityCommand() { Dto = dto });
      return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update([FromBody] RoomFacilityDto dto)
    {
      await _mediator.Send(new UpdateRoomFacilityCommand { Dto = dto });
      return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id)
    {
      var result = await _mediator.Send(new DeleteRoomFacilityCommand { RoomFacilityId = id });
      return NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(RoomFacilityDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
      var result = await _mediator.Send(new GetByIdRoomFacilityQuery() { Id = id });
      return Ok(result);
    }
  }
}
