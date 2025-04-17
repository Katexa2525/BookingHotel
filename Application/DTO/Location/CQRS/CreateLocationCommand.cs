using MediatR;

namespace Application.DTO.Location.CQRS
{
  public class CreateLocationCommand: IRequest<Guid>
  {
    public LocationCreateWithIdDto Dto { get; set; }
  }
}
