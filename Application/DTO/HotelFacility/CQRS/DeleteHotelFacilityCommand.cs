using MediatR;

namespace Application.DTO.HotelFacility.CQRS
{
  public class DeleteHotelFacilityCommand : IRequest<Unit>
  {
    public Guid HotelFacilityId { get; set; }
  }
}
