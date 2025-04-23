using MediatR;

namespace Application.DTO.RoomFacility.CQRS
{
  public class DeleteRoomFacilityCommand : IRequest<Unit>
  {
    public Guid RoomFacilityId { get; set; }
  }
}
