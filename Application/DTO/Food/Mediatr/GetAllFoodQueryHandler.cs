using Application.BussinessLogic.Food;
using Application.DTO.Food.CQRS;
using MediatR;

namespace Application.DTO.Food.Mediatr
{
  public class GetAllFoodQueryHandler : IRequestHandler<GetAllFoodQuery, List<FoodDto>>
  {
    private readonly IFoodBussinessLogic _bussinessLogic;

    public GetAllFoodQueryHandler(IFoodBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<List<FoodDto>> Handle(GetAllFoodQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetAllAsync(trackChanges: false);
    }
  }
}
