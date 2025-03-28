﻿using Application.DTO.Room;
using Application.DTO.Room.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Controllers
{
  [ApiController]
  [Route("room")]
  public class RoomController : ControllerBase
  {
    private readonly IMediator _mediator;
    public RoomController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<RoomDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
      var result = await _mediator.Send(new GetAllQuery() { });
      return Ok(result);
    }
  }
}
