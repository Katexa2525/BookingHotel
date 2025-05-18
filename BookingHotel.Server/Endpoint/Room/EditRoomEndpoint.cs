using Application.ConstMessages;
using Application.DTO.Room;
using Application.DTO.Room.ClientRequest;
using Application.DTO.Room.CQRS;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.Room
{
  public class EditRoomEndpoint : BaseAsyncEndpoint.WithRequest<EditRoomRequest>.WithResponse<bool>
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public EditRoomEndpoint(IMediator mediator, IMapper mapper)
    {
      _mediator = mediator;
      _mapper = mapper;
    }

    [HttpPut(EditRoomRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(EditRoomRequest request, CancellationToken cancellationToken = default)
    {
      // получаю номер из БД
      var room = await _mediator.Send(new GetByIdRoomQuery() { Id = request.room.Id });
      if (room is null)
      {
        return BadRequest(AppMessage.GetHotelByIdTextErrorMessage);
      }
      // обновляю модель отеля данными из запроса
      room.Description = request.room.Description;
      room.PeopleNumber = request.room.PeopleNumber;
      room.Square = request.room.Square;
      room.RoomTypeId = request.room.RoomTypeId;

      // сохраняю изменения
      var result = await _mediator.Send(new UpdateRoomCommand() { Dto = _mapper.Map<RoomUpdateDto>(room) });

      return Ok(true);
    }
  }
}
