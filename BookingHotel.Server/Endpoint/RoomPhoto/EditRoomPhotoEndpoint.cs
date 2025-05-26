using Application.ConstMessages;
using Application.DTO.RoomPhoto;
using Application.DTO.RoomPhoto.ClientRequest;
using Application.DTO.RoomPhoto.CQRS;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.RoomPhoto
{
  public class EditRoomPhotoEndpoint : BaseAsyncEndpoint.WithRequest<EditRoomPhotoRequest>.WithResponse<bool>
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public EditRoomPhotoEndpoint(IMediator mediator, IMapper mapper)
    {
      _mediator = mediator;
      _mapper = mapper;
    }

    [HttpPut(EditRoomPhotoRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(EditRoomPhotoRequest request, CancellationToken cancellationToken = default)
    {
      var roomPhoto = await _mediator.Send(new GetByIdRoomPhotoQuery() { Id = request.roomPhoto.Id });

      if (roomPhoto is null)
      {
        return BadRequest(AppMessage.GetRoomPhotoByIdTextErrorMessage);
      }

      // обновляю модель данными из запроса
      roomPhoto.Photo = request.roomPhoto.Photo;
      roomPhoto.RoomId = request.roomPhoto.RoomId;

      // сохраняю изменения
      var result = await _mediator.Send(new UpdateRoomPhotoCommand() { Dto = _mapper.Map<RoomPhotoDto>(roomPhoto) });

      return Ok(true);
    }
  }
}
