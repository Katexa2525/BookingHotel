using MediatR;

namespace Application.DTO.Hotel.CQRS
{
  public class CreateHotelCommand : IRequest<Guid>
  {
    public HotelCreateDto Dto { get; set; }
  }
}
