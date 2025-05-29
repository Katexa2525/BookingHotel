using Application.DTO.Review;
using Application.DTO.Review.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Controllers
{
  [ApiController]
  [Route("api/reviews")]
  public class ReviewController : ControllerBase
  {
    private readonly IMediator _mediator;

    public ReviewController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ReviewDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
      var result = await _mediator.Send(new GetAllReviewQuery() { });
      return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ReviewDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
      var result = await _mediator.Send(new GetByIdReviewQuery() { Id = id });
      return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id)
    {
      var result = await _mediator.Send(new DeleteReviewCommand { ReviewId = id });
      return NoContent();
    }

    [HttpPost]
    //[Route("create")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] ReviewCreateWithIdDto dto)
    {
      var result = await _mediator.Send(new CreateReviewCommand() { Dto = dto });
      return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update([FromBody] ReviewDto dto)
    {
      await _mediator.Send(new UpdateReviewCommand { Dto = dto });
      return NoContent();
    }
  }
}
