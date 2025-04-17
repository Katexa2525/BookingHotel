using Application.BussinessLogic.HotelFacility;
using Application.DTO.HotelFacility.CQRS;
using MediatR;

namespace Application.DTO.HotelFacility.Mediatr
{
  public class GetAllHotelFacilityQueryHandler : IRequestHandler<GetAllHotelFacilityQuery, List<HotelFacilityDto>>
  {
    private readonly IHotelFacilityBussinessLogic _bussinessLogic;
    public GetAllHotelFacilityQueryHandler(IHotelFacilityBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<List<HotelFacilityDto>> Handle(GetAllHotelFacilityQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetAllAsync();
    }
  }
}
