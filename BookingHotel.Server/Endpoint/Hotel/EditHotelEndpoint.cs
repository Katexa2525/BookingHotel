using Application.ConstMessages;
using Application.DTO.Hotel;
using Application.DTO.Hotel.ClientRequest;
using Application.DTO.Hotel.CQRS;
using Application.Enums;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.Hotel
{
  public class EditHotelEndpoint : BaseAsyncEndpoint.WithRequest<EditHotelRequest>.WithResponse<bool>
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public EditHotelEndpoint(IMediator mediator, IMapper mapper)
    {
      _mediator = mediator;
      _mapper = mapper;
    }

    //[HttpPut(EditHotelRequest.RouteTemplate)]
    [HttpPut("/api/hotels/v3")]
    public override async Task<ActionResult<bool>> HandleAsync(EditHotelRequest request, CancellationToken cancellationToken = default)
    {
      // получаю отель из БД
      var hotel = await _mediator.Send(new GetByIdHotelQuery() { Id = request.hotel.Id });
      if (hotel is null)
      {
        return BadRequest(AppMessage.GetHotelByIdTextErrorMessage);
      }

      // обновляю модель отеля данными из запроса
      hotel.Name = request.hotel.Name;
      hotel.Description = request.hotel.Description;
      hotel.Location = request.hotel.Location;
      hotel.Rating = request.hotel.Rating;
      hotel.Star = request.hotel.Star;

      if (request.hotel.ImageAction == ImageAction.Remove)
      {
        System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images", hotel.MainPhoto!));
        // Если свойство ImageAction получает значение Remove, то физический файл удаляется с диска,
        // а свойство MainPhoto получает значение null
        hotel.MainPhoto = null;
      }

      // сохраняю изменения
      var result = await _mediator.Send(new UpdateHotelCommand() { Dto = _mapper.Map<HotelUpdateDto>(hotel) });

      return Ok(true);
    }
  }
}
