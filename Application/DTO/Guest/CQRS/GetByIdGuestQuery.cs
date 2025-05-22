using MediatR;

namespace Application.DTO.Guest.CQRS
{
  public class GetByIdGuestQuery : IRequest<GuestDto>
  {
    public Guid Id { get; set; }
  }
}
