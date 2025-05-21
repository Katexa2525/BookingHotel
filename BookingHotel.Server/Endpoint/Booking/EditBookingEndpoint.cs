using Application.ConstMessages;
using Application.DTO.Booking;
using Application.DTO.Booking.ClientRequest;
using Application.DTO.Booking.CQRS;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.Booking
{
  public class EditBookingEndpoint : BaseAsyncEndpoint.WithRequest<EditBookingRequest>.WithResponse<bool>
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public EditBookingEndpoint(IMediator mediator, IMapper mapper)
    {
      _mediator = mediator;
      _mapper = mapper;
    }

    [HttpPut(EditBookingRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(EditBookingRequest request, CancellationToken cancellationToken = default)
    {
      // получаю отель из БД
      var booking = await _mediator.Send(new GetByIdBookingQuery() { Id = request.booking.Id });
      if (booking is null)
      {
        return BadRequest(AppMessage.GetBookingByIdTextErrorMessage);
      }

      //booking = request.booking;

      // обновляю модель отеля данными из запроса
      booking.Name = request.booking.Name;
      booking.Description = request.booking.Description;
      booking.DepartureDate = request.booking.DepartureDate;
      booking.ArrivalDate = request.booking.ArrivalDate;
      booking.NumberOfChilds = request.booking.NumberOfChilds;
      booking.NumberOfAdults = request.booking.NumberOfAdults;
      booking.RoomId = request.booking.RoomId;
      booking.Guests = request.booking.Guests;
      booking.Services = request.booking.Services;

      // сохраняю изменения
      var result = await _mediator.Send(new UpdateBookingCommand() { Dto = _mapper.Map<BookingUpdateDto>(booking) });

      return Ok(true);
    }
  }
}
