using MediatR;
namespace Application.DTO.Hotel.CQRS
{
  public class GetAllQuery : IRequest<List<HotelDto>>
  {

  }
}
