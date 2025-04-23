using Application.BussinessLogic.Location;
using Application.DTO.Location.CQRS;
using MediatR;

namespace Application.DTO.Location.Mediatr
{
  public class GetAllLocationQueryHandler : IRequestHandler<GetAllLocationQuery, List<LocationDto>>
  {
    private readonly ILocationBussinessLogic _bussinessLogic;
    public GetAllLocationQueryHandler(ILocationBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<List<LocationDto>> Handle(GetAllLocationQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetAllAsync();
    }
  }
}
