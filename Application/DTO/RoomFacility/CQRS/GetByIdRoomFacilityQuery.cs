using MediatR;

namespace Application.DTO.RoomFacility.CQRS
{
  public class GetByIdRoomFacilityQuery : IRequest<RoomFacilityDto>
  {
    public Guid Id { get; set; }
  }
}
