using MediatR;
namespace Application.DTO.Hotel.CQRS
{
  public class GetAllHotelQuery : IRequest<List<HotelAllDto>>
  {

  }
}
