using Application.BussinessLogic.Guest;
using Application.DTO.Guest.CQRS;
using MediatR;

namespace Application.DTO.Guest.Mediatr
{
  public class GetByIdGuestQueryHandler : IRequestHandler<GetByIdGuestQuery, GuestDto>
  {
    private readonly IGuestBussinessLogic _bussinessLogic;

    public GetByIdGuestQueryHandler(IGuestBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<GuestDto> Handle(GetByIdGuestQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetByIdAsync(request.Id, trackChanges: true);
    }
  }
}
