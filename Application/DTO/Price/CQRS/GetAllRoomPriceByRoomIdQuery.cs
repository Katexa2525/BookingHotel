using MediatR;

namespace Application.DTO.Price.CQRS
{
  public class GetAllRoomPriceByRoomIdQuery : IRequest<List<PriceDto>>
  {
    public Guid RoomId { get; set; }
  }
}
