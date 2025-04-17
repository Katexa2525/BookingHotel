using MediatR;

namespace Application.DTO.HotelFacility.CQRS
{
  public class GetAllHotelFacilityQuery : IRequest<List<HotelFacilityDto>>
  {
  }
}
