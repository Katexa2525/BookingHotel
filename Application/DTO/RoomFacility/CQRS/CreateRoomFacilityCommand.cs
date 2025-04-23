using MediatR;

namespace Application.DTO.RoomFacility.CQRS
{
  public class CreateRoomFacilityCommand : IRequest<Guid>
  {
    public RoomFacilityCreateWithIdDto Dto { get; set; }
  }
}
