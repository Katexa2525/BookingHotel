using Application.BussinessLogic.RoomFacility;
using Application.DTO.RoomFacility.CQRS;
using MediatR;

namespace Application.DTO.RoomFacility.Mediatr
{
  public class UpdateRoomFacilityCommandHandler : IRequestHandler<UpdateRoomFacilityCommand, Unit>
  {
    private readonly IRoomFacilityBussinessLogic _bussinessLogic;
    public UpdateRoomFacilityCommandHandler(IRoomFacilityBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<Unit> Handle(UpdateRoomFacilityCommand request, CancellationToken cancellationToken)
    {
      await _bussinessLogic.UpdateAsync(request.Dto);
      return Unit.Value;
    }
  }
}
