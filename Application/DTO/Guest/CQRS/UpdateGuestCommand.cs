using MediatR;

namespace Application.DTO.Guest.CQRS
{
  public class UpdateGuestCommand : IRequest<Unit>
  {
    public GuestUpdateDto Dto { get; set; }
  }
}
