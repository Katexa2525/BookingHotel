using MediatR;

namespace Application.DTO.HotelFacility.CQRS
{
  public class UpdateHotelFacilityCommand : IRequest<Unit>
  {
    public HotelFacilityDto Dto { get; set; }
  }
}
