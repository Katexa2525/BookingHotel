using MediatR;

namespace Application.DTO.Location.CQRS
{
  public class DeleteLocationCommand : IRequest<Unit>
  {
    public Guid LocationId { get; set; }
  }
}
