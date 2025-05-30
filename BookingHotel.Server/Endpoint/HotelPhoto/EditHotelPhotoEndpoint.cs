using Application.ConstMessages;
using Application.DTO.HotelPhoto;
using Application.DTO.HotelPhoto.ClientRequest;
using Application.DTO.HotelPhoto.CQRS;
using Application.DTO.RoomPhoto.ClientRequest;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.HotelPhoto
{
  public class EditHotelPhotoEndpoint : BaseAsyncEndpoint.WithRequest<EditHotelPhotoRequest>.WithResponse<bool>
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public EditHotelPhotoEndpoint(IMediator mediator, IMapper mapper)
    {
      _mediator = mediator;
      _mapper = mapper;
    }

    [HttpPut(EditRoomPhotoRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(EditHotelPhotoRequest request, CancellationToken cancellationToken = default)
    {
      var roomPhoto = await _mediator.Send(new GetByIdHotelPhotoQuery() { Id = request.hotelPhoto.Id });

      if (roomPhoto is null)
      {
        return BadRequest(AppMessage.GetHotelPhotoByIdTextErrorMessage);
      }

      // обновляю модель данными из запроса
      roomPhoto.Photo = request.hotelPhoto.Photo;
      roomPhoto.HotelId = request.hotelPhoto.HotelId;

      // сохраняю изменения
      var result = await _mediator.Send(new UpdateHotelPhotoCommand() { Dto = _mapper.Map<HotelPhotoDto>(roomPhoto) });

      return Ok(true);
    }
  }
}
