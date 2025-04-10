using MediatR;

namespace Application.DTO.Hotel.CQRS
{
  public class DeleteHotelCommand : IRequest<Unit>
  {
    public Guid HotelId { get; set; }
  }
}
