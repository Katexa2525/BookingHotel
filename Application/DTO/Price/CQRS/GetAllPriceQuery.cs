using MediatR;

namespace Application.DTO.Price.CQRS
{
  public class GetAllPriceQuery : IRequest<List<PriceDto>>
  {
  }
}
