using Application.ConstMessages;
using Application.DTO.RoomFacility;
using Application.DTO.RoomFacility.ClientRequest;
using Application.DTO.RoomFacility.CQRS;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.RoomFacility
{
  public class EditRoomFacilityEndpoint : BaseAsyncEndpoint.WithRequest<EditRoomFacilityRequest>.WithResponse<bool>
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public EditRoomFacilityEndpoint(IMediator mediator, IMapper mapper)
    {
      _mediator = mediator;
      _mapper = mapper;
    }

    [HttpPut(EditRoomFacilityRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(EditRoomFacilityRequest request, CancellationToken cancellationToken = default)
    {
      // получаю питание из БД
      var roomFacility = await _mediator.Send(new GetByIdRoomFacilityQuery() { Id = request.roomFacility.Id });
      if (roomFacility is null)
      {
        return BadRequest(AppMessage.GetHotelFacilityByIdTextErrorMessage);
      }

      // обновляю модель данными из запроса
      roomFacility.Name = request.roomFacility.Name;
      roomFacility.RoomId = request.roomFacility.RoomId;

      // сохраняю изменения
      var result = await _mediator.Send(new UpdateRoomFacilityCommand() { Dto = _mapper.Map<RoomFacilityDto>(roomFacility) });

      return Ok(true);
    }
  }
}
