using MediatR;

namespace Application.DTO.Location.CQRS
{
  public class GetAllLocationsByHotelIdQuery : IRequest<List<LocationDto>>
  {
    public Guid HotelId { get; set; }
  }
}
