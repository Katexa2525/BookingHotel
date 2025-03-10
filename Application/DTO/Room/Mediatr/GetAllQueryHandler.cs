using Application.BussinessLogic.Room;
using Application.DTO.Room.CQRS;
using MediatR;

namespace Application.DTO.Room.Mediatr
{
  public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<RoomDto>>
  {
    private readonly IRoomBussinessLogic _bussinessLogic;
    public GetAllQueryHandler(IRoomBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<List<RoomDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetAllAsync();
    }
  }
}
