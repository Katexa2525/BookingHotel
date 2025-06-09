using Application.DTO.TypeFood;
using Application.DTO.TypeFood.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Controllers
{
  [ApiController]
  [Route("api/typefoods")]
  public class TypeFoodController : ControllerBase
  {
    private readonly IMediator _mediator;

    public TypeFoodController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<TypeFoodDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<TypeFoodDto>>> GetAll()
    {
      var result = await _mediator.Send(new GetAllTypeFoodQuery() { });
      return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TypeFoodDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<TypeFoodDto>> GetById([FromRoute] Guid id)
    {
      var result = await _mediator.Send(new GetByIdTypeFoodQuery() { Id = id });
      return Ok(result);
    }

  }
}
