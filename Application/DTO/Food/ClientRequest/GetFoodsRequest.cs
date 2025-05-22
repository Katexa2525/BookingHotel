using Application.DTO.Booking;
using MediatR;

namespace Application.DTO.Food.ClientRequest
{
  public record GetFoodsRequest : IRequest<GetFoodsRequest.Response>
  {
    public const string RouteTemplate = "api/foods";

    public record Response(List<FoodDto>? Bookings);
  }
}
