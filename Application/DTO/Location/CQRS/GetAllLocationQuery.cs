using MediatR;

namespace Application.DTO.Location.CQRS
{
  public class GetAllLocationQuery : IRequest<List<LocationDto>>
  {
  }
}
