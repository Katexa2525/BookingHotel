using Application.BussinessLogic.Price;
using Application.DTO.Price.CQRS;
using MediatR;

namespace Application.DTO.Price.Mediatr
{
  public class GetAllPriceQueryHandler : IRequestHandler<GetAllPriceQuery, List<PriceDto>>
  {
    private readonly IPriceBussinessLogic _bussinessLogic;
    public GetAllPriceQueryHandler(IPriceBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<List<PriceDto>> Handle(GetAllPriceQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetAllAsync(trackChanges: true);
    }
  }
}
