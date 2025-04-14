using Application.BussinessLogic.Price;
using Application.DTO.Price.CQRS;
using MediatR;

namespace Application.DTO.Price.Mediatr
{
  public class UpdatePriceCommandHandler : IRequestHandler<UpdatePriceCommand, Unit>
  {
    private readonly IPriceBussinessLogic _bussinessLogic;
    public UpdatePriceCommandHandler(IPriceBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<Unit> Handle(UpdatePriceCommand request, CancellationToken cancellationToken)
    {
      await _bussinessLogic.UpdateAsync(request.Dto);
      return Unit.Value;
    }
  }
}
