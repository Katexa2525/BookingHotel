using Application.BussinessLogic.Location;
using Application.DTO.Location.CQRS;
using MediatR;

namespace Application.DTO.Location.Mediatr
{
  public class GetByIdLocationQueryHandler : IRequestHandler<GetByIdLocationQuery, LocationDto>
  {
    private readonly ILocationBussinessLogic _bussinessLogic;
    public GetByIdLocationQueryHandler(ILocationBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<LocationDto> Handle(GetByIdLocationQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetByIdAsync(request.Id, trackChanges: true);
    }
  }
}
