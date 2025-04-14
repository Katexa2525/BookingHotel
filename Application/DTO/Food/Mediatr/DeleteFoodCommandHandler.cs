using Application.BussinessLogic.Food;
using Application.DTO.Food.CQRS;
using MediatR;

namespace Application.DTO.Food.Mediatr
{
  public class DeleteFoodCommandHandler : IRequestHandler<DeleteFoodCommand, Unit>
  {
    private readonly IFoodBussinessLogic _bussinessLogic;
    public DeleteFoodCommandHandler(IFoodBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<Unit> Handle(DeleteFoodCommand request, CancellationToken cancellationToken)
    {
      await _bussinessLogic.DeleteAsync(request.FoodId);
      return Unit.Value;
    }
  }
}
