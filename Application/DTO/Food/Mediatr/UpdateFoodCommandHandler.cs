using Application.BussinessLogic.Food;
using Application.DTO.Food.CQRS;
using MediatR;

namespace Application.DTO.Food.Mediatr
{
  public class UpdateFoodCommandHandler : IRequestHandler<UpdateFoodCommand, Unit>
  {
    private readonly IFoodBussinessLogic _bussinessLogic;
    public UpdateFoodCommandHandler(IFoodBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<Unit> Handle(UpdateFoodCommand request, CancellationToken cancellationToken)
    {
      await _bussinessLogic.UpdateAsync(request.Dto);
      return Unit.Value;
    }
  }
}
