using MediatR;

namespace Application.DTO.HotelFacility.CQRS
{
  public class GetAllHotelFacilityByHotelIdQuery : IRequest<List<HotelFacilityDto>>
  {
    public Guid HotelId { get; set; }
  }
}
