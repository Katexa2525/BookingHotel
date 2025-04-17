using MediatR;

namespace Application.DTO.Location.CQRS
{
  public class GetByIdLocationQuery : IRequest<LocationDto>
  {
    public Guid Id { get; set; }
  }
}
