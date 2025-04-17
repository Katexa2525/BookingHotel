using Application.DTO.HotelFacility;
using Application.DTO.HotelFacility.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Controllers
{
  [ApiController]
  [Route("hotelFacility")]
  public class HotelFacilityController : ControllerBase
  {
    private readonly IMediator _mediator;
    public HotelFacilityController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<HotelFacilityDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
      var result = await _mediator.Send(new GetAllHotelFacilityQuery() { });
      return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] HotelFacilityCreateWithIdDto dto)
    {
      var result = await _mediator.Send(new CreateHotelFacilityCommand() { Dto = dto });
      return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update([FromBody] HotelFacilityDto dto)
    {
      await _mediator.Send(new UpdateHotelFacilityCommand { Dto = dto });
      return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id)
    {
      var result = await _mediator.Send(new DeleteHotelFacilityCommand { HotelFacilityId = id });
      return NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(HotelFacilityDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
      var result = await _mediator.Send(new GetByIdHotelFacilityQuery() { Id = id });
      return Ok(result);
    }
  }
}
