using MediatR;

namespace Application.DTO.Hotel.CQRS
{
  public class GetByIdHotelQuery : IRequest<HotelDto>
  {
    public Guid Id { get; set; }
  }
}
