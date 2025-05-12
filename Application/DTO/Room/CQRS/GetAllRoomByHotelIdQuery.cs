using MediatR;

namespace Application.DTO.Room.CQRS
{
  public class GetAllRoomByHotelIdQuery : IRequest<List<RoomDto>>
  {
    public Guid HotelId { get; set; }
  }
}
