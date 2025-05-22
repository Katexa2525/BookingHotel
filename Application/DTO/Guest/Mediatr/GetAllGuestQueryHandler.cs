using Application.BussinessLogic.Guest;
using Application.DTO.Guest.CQRS;
using MediatR;

namespace Application.DTO.Guest.Mediatr
{
  public class GetAllGuestQueryHandler : IRequestHandler<GetAllGuestQuery, List<GuestAllDto>>
  {
    private readonly IGuestBussinessLogic _bussinessLogic;

    public GetAllGuestQueryHandler(IGuestBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<List<GuestAllDto>> Handle(GetAllGuestQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetAllAsync(trackChanges: true);
    }
  }
}
