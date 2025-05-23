using Application.BussinessLogic.HotelFacility;
using Application.DTO.HotelFacility.CQRS;
using MediatR;

namespace Application.DTO.HotelFacility.Mediatr
{
  public class GetByIdHotelFacilityQueryHandler : IRequestHandler<GetByIdHotelFacilityQuery, HotelFacilityDto>
  {
    private readonly IHotelFacilityBussinessLogic _bussinessLogic;
    public GetByIdHotelFacilityQueryHandler(IHotelFacilityBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<HotelFacilityDto> Handle(GetByIdHotelFacilityQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetByIdAsync(request.Id, trackChanges: false);
    }
  }
}
