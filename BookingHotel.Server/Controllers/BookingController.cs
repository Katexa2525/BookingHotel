using Application.DTO.Booking;
using Application.DTO.Booking.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Controllers
{
  [ApiController]
  [Route("api/bookings")]
  public class BookingController : ControllerBase
  {
    private readonly IMediator _mediator;

    public BookingController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<BookingDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<BookingDto>>> GetAll()
    {
      var result = await _mediator.Send(new GetAllBookingQuery() { });
      return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BookingDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<BookingDto>> GetById([FromRoute] Guid id)
    {
      var result = await _mediator.Send(new GetByIdBookingQuery() { Id = id });
      return Ok(result);
    }

    [HttpPost]
    //[Route("create")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] BookingCreateDto dto)
    {
      var result = await _mediator.Send(new CreateBookingCommand() { Dto = dto });
      return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id)
    {
      var result = await _mediator.Send(new DeleteBookingCommand { BookingId = id });
      return NoContent();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update([FromBody] BookingUpdateDto dto)
    {
      await _mediator.Send(new UpdateBookingCommand { Dto = dto });
      return NoContent();
    }

  }
}
