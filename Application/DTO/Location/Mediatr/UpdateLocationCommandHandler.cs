using Application.BussinessLogic.Location;
using Application.DTO.Location.CQRS;
using MediatR;

namespace Application.DTO.Location.Mediatr
{
  public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, Unit>
  {
    private readonly ILocationBussinessLogic _bussinessLogic;
    public UpdateLocationCommandHandler(ILocationBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<Unit> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
      await _bussinessLogic.UpdateAsync(request.Dto);
      return Unit.Value;
    }
  }
}
