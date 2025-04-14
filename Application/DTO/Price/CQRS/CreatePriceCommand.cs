using MediatR;

namespace Application.DTO.Price.CQRS
{
  public class CreatePriceCommand : IRequest<Guid>
  {
    public PriceCreateWithIdDto Dto { get; set; }
  }
}
