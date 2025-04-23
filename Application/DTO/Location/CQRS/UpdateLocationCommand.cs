using MediatR;

namespace Application.DTO.Location.CQRS
{
  public class UpdateLocationCommand : IRequest<Unit>
  {
    public LocationDto Dto { get; set; }
  }
}
