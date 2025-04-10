using Application.BussinessLogic.Room;
using Application.DTO.Room.CQRS;
using MediatR;

namespace Application.DTO.Room.Mediatr
{
  public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, Unit>
  {
    private readonly IRoomBussinessLogic _bussinessLogic;
    public DeleteRoomCommandHandler(IRoomBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
      await _bussinessLogic.DeleteAsync(request.RoomId);
      return Unit.Value;
    }
  }
}
