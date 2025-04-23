using MediatR;

namespace Application.DTO.HotelFacility.CQRS
{
  public class CreateHotelFacilityCommand : IRequest<Guid>
  {
    public HotelFacilityCreateWithIdDto Dto { get; set; }
  }
}
