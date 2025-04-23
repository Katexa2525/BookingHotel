using MediatR;

namespace Application.DTO.RoomFacility.CQRS
{
  public class GetAllRoomFacilityQuery : IRequest<List<RoomFacilityDto>>
  {
  }
}
