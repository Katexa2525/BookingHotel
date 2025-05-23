using Application.BussinessLogic.HotelFacility;
using Application.DTO.HotelFacility.CQRS;
using MediatR;

namespace Application.DTO.HotelFacility.Mediatr
{
  public class GetAllHotelFacilityByHotelIdQueryHandler : IRequestHandler<GetAllHotelFacilityByHotelIdQuery, List<HotelFacilityDto>>
  {
    private readonly IHotelFacilityBussinessLogic _bussinessLogic;

    public GetAllHotelFacilityByHotelIdQueryHandler(IHotelFacilityBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<List<HotelFacilityDto>> Handle(GetAllHotelFacilityByHotelIdQuery request, CancellationToken cancellationToken)
    {
      return _bussinessLogic.GetByCondition(p => p.HotelId == request.HotelId, trackChanges: false);
    }
  }
}
