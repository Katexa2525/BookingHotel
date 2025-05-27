using Application.BussinessLogic.Price;
using Application.DTO.Price.CQRS;
using MediatR;

namespace Application.DTO.Price.Mediatr
{
  public class DeletePriceCommandHandler : IRequestHandler<DeletePriceCommand, Unit>
  {
    private readonly IPriceBussinessLogic _bussinessLogic;

    public DeletePriceCommandHandler(IPriceBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<Unit> Handle(DeletePriceCommand request, CancellationToken cancellationToken)
    {
      await _bussinessLogic.DeleteAsync(request.PriceId);
      return Unit.Value;
    }
  }
}
