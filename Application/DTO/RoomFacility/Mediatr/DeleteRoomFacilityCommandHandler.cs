using Application.BussinessLogic.RoomFacility;
using Application.DTO.RoomFacility.CQRS;
using MediatR;

namespace Application.DTO.RoomFacility.Mediatr
{
  public class DeleteRoomFacilityCommandHandler : IRequestHandler<DeleteRoomFacilityCommand, Unit>
  {
    private readonly IRoomFacilityBussinessLogic _bussinessLogic;
    public DeleteRoomFacilityCommandHandler(IRoomFacilityBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<Unit> Handle(DeleteRoomFacilityCommand request, CancellationToken cancellationToken)
    {
      await _bussinessLogic.DeleteAsync(request.RoomFacilityId);
      return Unit.Value;
    }
  }
}
