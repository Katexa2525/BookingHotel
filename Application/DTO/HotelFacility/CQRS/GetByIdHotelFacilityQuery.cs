using MediatR;

namespace Application.DTO.HotelFacility.CQRS
{
  public class GetByIdHotelFacilityQuery : IRequest<HotelFacilityDto>
  {
    public Guid Id { get; set; }
  }
}
