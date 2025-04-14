using Application.DTO.Food;
using Application.DTO.Food.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Controllers
{
  [ApiController]
  [Route("food")]
  public class FoodController : ControllerBase
  {
    private readonly IMediator _mediator;
    public FoodController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<FoodDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
      var result = await _mediator.Send(new GetAllFoodQuery() { });
      return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] FoodCreateWithIdDto dto)
    {
      var result = await _mediator.Send(new CreateFoodCommand() { Dto = dto });
      return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update([FromBody] FoodDto dto)
    {
      await _mediator.Send(new UpdateFoodCommand { Dto = dto });
      return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id)
    {
      var result = await _mediator.Send(new DeleteFoodCommand { FoodId = id });
      return NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(FoodDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
      var result = await _mediator.Send(new GetByIdFoodQuery() { Id = id });
      return Ok(result);
    }
  }
}
