using MediatR;

namespace Application.DTO.Guest.CQRS
{
  public class CreateGuestCommand : IRequest<Guid>
  {
    public GuestCreateDto Dto { get; set; }
  }
}
