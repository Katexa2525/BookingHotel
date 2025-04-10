using MediatR;

namespace Application.DTO.Hotel.CQRS
{
  public class UpdateHotelCommand : IRequest<Unit>
  {
    public HotelUpdateDto Dto { get; set; }
  }
}
