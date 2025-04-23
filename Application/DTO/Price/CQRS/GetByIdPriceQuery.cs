using MediatR;

namespace Application.DTO.Price.CQRS
{
  public class GetByIdPriceQuery : IRequest<PriceDto>
  {
    public Guid Id { get; set; }
  }
}
