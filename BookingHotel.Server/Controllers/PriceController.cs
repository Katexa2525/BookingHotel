using Application.DTO.Food;
using Application.DTO.Price;
using Application.DTO.Price.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Controllers
{
  [ApiController]
  [Route("prices")]
  public class PriceController : ControllerBase
  {
    private readonly IMediator _mediator;
    public PriceController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<PriceDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
      var result = await _mediator.Send(new GetAllPriceQuery() { });
      return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] PriceCreateWithIdDto dto)
    {
      var result = await _mediator.Send(new CreatePriceCommand() { Dto = dto });
      return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update([FromBody] PriceDto dto)
    {
      await _mediator.Send(new UpdatePriceCommand { Dto = dto });
      return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id)
    {
      var result = await _mediator.Send(new DeletePriceCommand { PriceId = id });
      return NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(FoodDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
      var result = await _mediator.Send(new GetByIdPriceQuery() { Id = id });
      return Ok(result);
    }
  }
}
