using Application.DTO.Guest;
using Application.DTO.Guest.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Controllers
{
  [ApiController]
  [Route("api/guests")]
  public class GuestController : ControllerBase
  {
    private readonly IMediator _mediator;

    public GuestController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<GuestDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<GuestDto>>> GetAll()
    {
      var result = await _mediator.Send(new GetAllGuestQuery() { });
      return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GuestDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<GuestDto>> GetById([FromRoute] Guid id)
    {
      var result = await _mediator.Send(new GetByIdGuestQuery() { Id = id });
      return Ok(result);
    }

    [HttpPost]
    //[Route("create")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] GuestCreateDto dto)
    {
      var result = await _mediator.Send(new CreateGuestCommand() { Dto = dto });
      return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id)
    {
      var result = await _mediator.Send(new DeleteGuestCommand { BookingId = id });
      return NoContent();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update([FromBody] GuestUpdateDto dto)
    {
      await _mediator.Send(new UpdateGuestCommand { Dto = dto });
      return NoContent();
    }

  }
}
