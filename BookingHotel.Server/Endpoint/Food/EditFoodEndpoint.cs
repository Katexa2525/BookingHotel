using Application.ConstMessages;
using Application.DTO.Booking.ClientRequest;
using Application.DTO.Food;
using Application.DTO.Food.ClientRequest;
using Application.DTO.Food.CQRS;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.Food
{
  public class EditFoodEndpoint : BaseAsyncEndpoint.WithRequest<EditFoodRequest>.WithResponse<bool>
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public EditFoodEndpoint(IMediator mediator, IMapper mapper)
    {
      _mediator = mediator;
      _mapper = mapper;
    }

    [HttpPut(EditBookingRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(EditFoodRequest request, CancellationToken cancellationToken = default)
    {
      // получаю питание из БД
      var food = await _mediator.Send(new GetByIdFoodQuery() { Id = request.food.Id });
      if (food is null)
      {
        return BadRequest(AppMessage.GetFoodByIdTextErrorMessage);
      }

      // обновляю модель данными из запроса
      food.Name = request.food.Name;
      food.TypeFoodId = request.food.TypeFoodId;
      food.HotelId = request.food.HotelId;

      // сохраняю изменения
      var result = await _mediator.Send(new UpdateFoodCommand() { Dto = _mapper.Map<FoodDto>(food) });

      return Ok(true);
    }
  }
}
