using Application.ConstMessages;
using Application.DTO.HotelFacility;
using Application.DTO.HotelFacility.ClientRequest;
using Application.DTO.HotelFacility.CQRS;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.HotelFacility
{
  public class EditHotelFacilityEndpoint : BaseAsyncEndpoint.WithRequest<EditHotelFacilityRequest>.WithResponse<bool>
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public EditHotelFacilityEndpoint(IMediator mediator, IMapper mapper)
    {
      _mediator = mediator;
      _mapper = mapper;
    }

    [HttpPut(EditHotelFacilityRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(EditHotelFacilityRequest request, CancellationToken cancellationToken = default)
    {
      // получаю питание из БД
      var hotelFacility = await _mediator.Send(new GetByIdHotelFacilityQuery() { Id = request.hotelFacility.Id });
      if (hotelFacility is null)
      {
        return BadRequest(AppMessage.GetHotelFacilityByIdTextErrorMessage);
      }

      // обновляю модель данными из запроса
      hotelFacility.Name = request.hotelFacility.Name;
      hotelFacility.HotelId = request.hotelFacility.HotelId;

      // сохраняю изменения
      var result = await _mediator.Send(new UpdateHotelFacilityCommand() { Dto = _mapper.Map<HotelFacilityDto>(hotelFacility) });

      return Ok(true);
    }
  }
}
