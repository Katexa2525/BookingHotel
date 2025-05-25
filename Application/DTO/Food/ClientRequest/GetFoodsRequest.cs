using Application.DTO.Booking;
using MediatR;

namespace Application.DTO.Food.ClientRequest
{
  public record GetFoodsRequest(Guid hotelId) : IRequest<GetFoodsRequest.Response>
  {
    public const string RouteTemplate = "api/hotels/{hotelId}/foods";

    public record Response(List<FoodDto>? Foods);
  }
}
