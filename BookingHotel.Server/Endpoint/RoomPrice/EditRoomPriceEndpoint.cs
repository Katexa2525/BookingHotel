using Application.ConstMessages;
using Application.DTO.Price;
using Application.DTO.Price.ClientRequest;
using Application.DTO.Price.CQRS;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace BookingHotel.Server.Endpoint.RoomPrice
{
  public class EditRoomPriceEndpoint : BaseAsyncEndpoint.WithRequest<EditPriceRequest>.WithResponse<bool>
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public EditRoomPriceEndpoint(IMediator mediator, IMapper mapper)
    {
      _mediator = mediator;
      _mapper = mapper;
    }

    [HttpPut(EditPriceRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(EditPriceRequest request, CancellationToken cancellationToken = default)
    {
      var roomPrice = await _mediator.Send(new GetByIdPriceQuery() { Id = request.price.Id });

      if (roomPrice is null)
      {
        return BadRequest(AppMessage.GetPriceByIdTextErrorMessage);
      }

      // обновляю модель данными из запроса
      roomPrice.DayPrice = request.price.DayPrice;
      roomPrice.CurrencyId = request.price.CurrencyId;
      roomPrice.DateStart = request.price.DateStart;
      roomPrice.DateEnd = request.price.DateEnd;
      roomPrice.RoomId = request.price.RoomId;

      // сохраняю изменения
      var result = await _mediator.Send(new UpdatePriceCommand() { Dto = _mapper.Map<PriceDto>(roomPrice) });

      return Ok(true);
    }
  }
}
