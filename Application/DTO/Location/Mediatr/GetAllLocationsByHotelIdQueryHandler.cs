using Application.BussinessLogic.Location;
using Application.DTO.Location.CQRS;
using MediatR;

namespace Application.DTO.Location.Mediatr
{
  public class GetAllLocationsByHotelIdQueryHandler : IRequestHandler<GetAllLocationsByHotelIdQuery, List<LocationDto>>
  {
    private readonly ILocationBussinessLogic _bussinessLogic;

    public GetAllLocationsByHotelIdQueryHandler(ILocationBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<List<LocationDto>> Handle(GetAllLocationsByHotelIdQuery request, CancellationToken cancellationToken)
    {
      return _bussinessLogic.GetByCondition(p => p.HotelId == request.HotelId, trackChanges: false);
    }
  }
}
