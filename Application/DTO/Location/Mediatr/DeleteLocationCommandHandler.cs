using Application.BussinessLogic.Location;
using Application.DTO.Location.CQRS;
using MediatR;

namespace Application.DTO.Location.Mediatr
{
  public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, Unit>
  {
    private readonly ILocationBussinessLogic _bussinessLogic;
    public DeleteLocationCommandHandler(ILocationBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<Unit> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
      await _bussinessLogic.DeleteAsync(request.FoodId);
      return Unit.Value;
    }
  }
}
