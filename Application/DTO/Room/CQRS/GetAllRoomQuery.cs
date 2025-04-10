using MediatR;

namespace Application.DTO.Room.CQRS
{
  public class GetAllRoomQuery : IRequest<List<RoomAllDto>>
  {
  }
}
