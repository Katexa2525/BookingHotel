using Application.DTO.RoomPhoto;
using Application.DTO.RoomPhoto.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Controllers
{
  [ApiController]
  [Route("roomPhoto")]
  public class RoomPhotoController : ControllerBase
  {
    private readonly IMediator _mediator;
    public RoomPhotoController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] RoomPhotoCreateWithIdDto dto)
    {
      var result = await _mediator.Send(new CreateRoomPhotoCommand() { Dto = dto });
      return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id)
    {
      var result = await _mediator.Send(new DeleteRoomPhotoCommand { RoomPhotoId = id });
      return NoContent();
    }
  }
}
