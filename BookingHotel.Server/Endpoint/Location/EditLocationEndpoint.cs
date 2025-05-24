using Application.ConstMessages;
using Application.DTO.Location;
using Application.DTO.Location.ClientRequest;
using Application.DTO.Location.CQRS;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.Location
{
  public class EditLocationEndpoint : BaseAsyncEndpoint.WithRequest<EditLocationRequest>.WithResponse<bool>
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public EditLocationEndpoint(IMediator mediator, IMapper mapper)
    {
      _mediator = mediator;
      _mapper = mapper;
    }

    [HttpPut(EditLocationRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(EditLocationRequest request, CancellationToken cancellationToken = default)
    {
      // получаю питание из БД
      var location = await _mediator.Send(new GetByIdLocationQuery() { Id = request.location.Id });
      if (location is null)
      {
        return BadRequest(AppMessage.GetLocationByIdTextErrorMessage);
      }

      // обновляю модель данными из запроса
      location.Name = request.location.Name;
      location.HotelId = request.location.HotelId;

      // сохраняю изменения
      var result = await _mediator.Send(new UpdateLocationCommand() { Dto = _mapper.Map<LocationDto>(location) });

      return Ok(true);
    }
  }
}
