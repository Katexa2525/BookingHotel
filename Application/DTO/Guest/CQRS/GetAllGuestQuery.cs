using MediatR;

namespace Application.DTO.Guest.CQRS
{
  public class GetAllGuestQuery : IRequest<List<GuestAllDto>>
  {
  }
}
