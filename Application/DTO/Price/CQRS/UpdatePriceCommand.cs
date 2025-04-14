using MediatR;

namespace Application.DTO.Price.CQRS
{
  public class UpdatePriceCommand : IRequest<Unit>
  {
    public PriceDto Dto { get; set; }
  }
}
