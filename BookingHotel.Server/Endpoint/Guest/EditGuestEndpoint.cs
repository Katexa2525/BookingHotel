using Application.ConstMessages;
using Application.DTO.Guest;
using Application.DTO.Guest.ClientRequest;
using Application.DTO.Guest.CQRS;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.Guest
{
  public class EditGuestEndpoint : BaseAsyncEndpoint.WithRequest<EditGuestRequest>.WithResponse<bool>
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public EditGuestEndpoint(IMediator mediator, IMapper mapper)
    {
      _mediator = mediator;
      _mapper = mapper;
    }

    [HttpPut(EditGuestRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(EditGuestRequest request, CancellationToken cancellationToken = default)
    {
      // получаю бронирование из БД
      var guest = await _mediator.Send(new GetByIdGuestQuery() { Id = request.guest.Id });
      if (guest is null)
      {
        return BadRequest(AppMessage.GetGuestByIdTextErrorMessage);
      }

      // обновляю модель данными из запроса
      guest = request.guest;

      // сохраняю изменения
      var result = await _mediator.Send(new UpdateGuestCommand() { Dto = _mapper.Map<GuestUpdateDto>(guest) });

      return Ok(true);
    }
  }
}
