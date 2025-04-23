using MediatR;

namespace Application.DTO.RoomType.CQRS
{
  public class GetAllRoomTypeQuery : IRequest<List<RoomTypeAllDto>>
  {
  }
}
