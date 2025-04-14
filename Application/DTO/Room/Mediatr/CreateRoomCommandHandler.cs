using Application.BussinessLogic.Room;
using Application.DTO.Room.CQRS;
using MediatR;

namespace Application.DTO.Room.Mediatr
{
  public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Guid>
  {
    private readonly IRoomBussinessLogic _bussinessLogic;
    public CreateRoomCommandHandler(IRoomBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<Guid> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.CreateAsync(request.Dto);
    }
  }
}
