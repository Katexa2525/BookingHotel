using Application.DTO.Hotel;
using Application.DTO.Hotel.CQRS;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Controllers
{
  [ApiController]
  [Route("api/hotels/v3")]
  public class HotelController : ControllerBase
  {
    private readonly IMediator _mediator;

    public HotelController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<HotelAllDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
      var result = await _mediator.Send(new GetAllHotelQuery() { });
      return Ok(result);
    }

    [Route("create")]
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] HotelCreateDto dto)
    {
      var result = await _mediator.Send(new CreateHotelCommand() { Dto = dto });
      return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(HotelDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
      var result = await _mediator.Send(new GetByIdHotelQuery() { Id = id });
      return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id)
    {
      var result = await _mediator.Send(new DeleteHotelCommand { HotelId = id });
      return NoContent();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update([FromBody] HotelUpdateDto dto)
    {
      await _mediator.Send(new UpdateHotelCommand { Dto = dto });
      return NoContent();
    }
  }
}
