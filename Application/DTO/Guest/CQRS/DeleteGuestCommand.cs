using MediatR;

namespace Application.DTO.Guest.CQRS
{
  public class DeleteGuestCommand : IRequest<Unit>
  {
    public Guid BookingId { get; set; }
  }
}
