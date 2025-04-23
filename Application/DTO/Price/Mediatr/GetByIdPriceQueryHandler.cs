using Application.BussinessLogic.Price;
using Application.DTO.Price.CQRS;
using MediatR;

namespace Application.DTO.Price.Mediatr
{
  public class GetByIdPriceQueryHandler : IRequestHandler<GetByIdPriceQuery, PriceDto>
  {
    private readonly IPriceBussinessLogic _bussinessLogic;
    public GetByIdPriceQueryHandler(IPriceBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<PriceDto> Handle(GetByIdPriceQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetByIdAsync(request.Id);
    }
  }
}
