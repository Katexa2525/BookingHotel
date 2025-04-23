using Application.BussinessLogic.Price;
using Application.DTO.Price.CQRS;
using MediatR;

namespace Application.DTO.Price.Mediatr
{
  public class CreatePriceCommandHandler : IRequestHandler<CreatePriceCommand, Guid>
  {
    private readonly IPriceBussinessLogic _bussinessLogic;
    public CreatePriceCommandHandler(IPriceBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<Guid> Handle(CreatePriceCommand request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.CreateAsync(request.Dto);
    }
  }
}
