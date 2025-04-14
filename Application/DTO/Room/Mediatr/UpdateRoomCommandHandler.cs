using Application.BussinessLogic.Room;
using Application.DTO.Room.CQRS;
using MediatR;

namespace Application.DTO.Room.Mediatr
{
  public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, Unit>
  {
    private readonly IRoomBussinessLogic _bussinessLogic;
    public UpdateRoomCommandHandler(IRoomBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
      await _bussinessLogic.UpdateAsync(request.Dto);
      return Unit.Value;
    }
  }
}
