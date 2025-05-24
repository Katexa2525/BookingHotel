using Application.BussinessLogic.Price;
using Application.DTO.Price.CQRS;
using MediatR;

namespace Application.DTO.Price.Mediatr
{
  public class GetAllRoomPriceByRoomIdQueryHandler : IRequestHandler<GetAllRoomPriceByRoomIdQuery, List<PriceDto>>
  {
    private readonly IPriceBussinessLogic _bussinessLogic;

    public GetAllRoomPriceByRoomIdQueryHandler(IPriceBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<List<PriceDto>> Handle(GetAllRoomPriceByRoomIdQuery request, CancellationToken cancellationToken)
    {
      return _bussinessLogic.GetByCondition(p => p.RoomId == request.RoomId, trackChanges: false);
    }
  }
}
