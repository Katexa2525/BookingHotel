using MediatR;

namespace Application.DTO.RoomFacility.CQRS
{
  public class GetAllRoomFacilityByRoomIdQuery : IRequest<List<RoomFacilityDto>>
  {
    public Guid RoomId { get; set; }
  }
}
