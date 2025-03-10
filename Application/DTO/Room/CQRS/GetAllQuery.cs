using MediatR;

namespace Application.DTO.Room.CQRS
{
  public class GetAllQuery : IRequest<List<RoomDto>>
  {
  }
}
