using Application.DTO.Food;
using Application.DTO.Food.CQRS;
using Application.DTO.Hotel;
using Application.DTO.Hotel.CQRS;
using Application.DTO.HotelFacility;
using Application.DTO.HotelFacility.CQRS;
using Application.DTO.Location;
using Application.DTO.Location.CQRS;
using Application.DTO.Room;
using Application.DTO.Room.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Controllers
{
  [ApiController]
  [Route("api/hotels")]
  public class HotelController : ControllerBase
  {
    private readonly IMediator _mediator;

    public HotelController(IMediator mediator) 
    {
      _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<HotelAllDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<HotelAllDto>>> GetAll()
    {
      var result = await _mediator.Send(new GetAllHotelQuery() { });
      return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(HotelDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<HotelDto>> GetById([FromRoute] Guid id)
    {
      var result = await _mediator.Send(new GetByIdHotelQuery() { Id = id });
      return Ok(result);
    }

    [HttpGet]
    [Route("{hotelid}/rooms")]
    [ProducesResponseType(typeof(List<RoomDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<RoomDto>>> GetRoomsByHotelId([FromRoute] Guid hotelid)
    {
      var result = await _mediator.Send(new GetAllRoomByHotelIdQuery() { HotelId = hotelid });
      return Ok(result);
    }

    [HttpGet]
    [Route("{hotelid}/facilities")]
    [ProducesResponseType(typeof(List<HotelFacilityDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<HotelFacilityDto>>> GetFacilitiesByHotelId([FromRoute] Guid hotelid)
    {
      var result = await _mediator.Send(new GetAllHotelFacilityByHotelIdQuery() { HotelId = hotelid });
      return Ok(result);
    }

    [HttpGet]
    [Route("{hotelid}/locations")]
    [ProducesResponseType(typeof(List<LocationDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<LocationDto>>> GetLocationsByHotelId([FromRoute] Guid hotelid)
    {
      var result = await _mediator.Send(new GetAllLocationsByHotelIdQuery() { HotelId = hotelid });
      return Ok(result);
    }

    [HttpGet]
    [Route("{hotelid}/foods")]
    [ProducesResponseType(typeof(List<FoodDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<FoodDto>>> GetFoodsByHotelId([FromRoute] Guid hotelid)
    {
      var result = await _mediator.Send(new GetAllFoodByHotelIdQuery() { HotelId = hotelid });
      return Ok(result);
    }

    [HttpPost]
    //[Route("create")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] HotelCreateDto dto)
    {
      var result = await _mediator.Send(new CreateHotelCommand() { Dto = dto });
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
