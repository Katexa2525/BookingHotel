using Application.BussinessLogic.RoomFacility;
using Application.DTO.RoomFacility.CQRS;
using MediatR;

namespace Application.DTO.RoomFacility.Mediatr
{
  public class CreateRoomFacilityCommandHandler : IRequestHandler<CreateRoomFacilityCommand, Guid>
  {
    private readonly IRoomFacilityBussinessLogic _bussinessLogic;
    public CreateRoomFacilityCommandHandler(IRoomFacilityBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<Guid> Handle(CreateRoomFacilityCommand request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.CreateAsync(request.Dto);
    }
  }
}
