using Application.DTO.Hotel;
using Application.DTO.Hotel.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Controllers
{
  [ApiController]
  [Route("hotel")]
  public class HotelController : ControllerBase
  {
    private readonly IMediator _mediator;
    public HotelController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<HotelDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
      var result = await _mediator.Send(new GetAllQuery() { });
      return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] HotelCreateDto dto)
    {
      var result = await _mediator.Send(new CreateHotelCommand() { Dto = dto });
      return Ok(result);
    }
  }
}
