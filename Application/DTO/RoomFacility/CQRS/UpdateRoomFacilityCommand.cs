using MediatR;

namespace Application.DTO.RoomFacility.CQRS
{
  public class UpdateRoomFacilityCommand : IRequest<Unit>
  {
    public RoomFacilityDto Dto { get; set; }
  }
}
