using Application.DTO.HotelPhoto;
using Application.DTO.HotelPhoto.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Controllers
{
  [ApiController]
  [Route("api/hotelphotos")]
  public class HotelPhotoController : ControllerBase
  {
    private readonly IMediator _mediator;
    public HotelPhotoController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(HotelPhotoDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
      var result = await _mediator.Send(new GetByIdHotelPhotoQuery() { Id = id });
      return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] HotelPhotoCreateWithIdDto dto)
    {
      var result = await _mediator.Send(new CreateHotelPhotoCommand() { Dto = dto });
      return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id)
    {
      var result = await _mediator.Send(new DeleteHotelPhotoCommand { HotelPhotoId = id });
      return NoContent();
    }
  }
}
