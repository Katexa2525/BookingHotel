using Application.BussinessLogic.Food;
using Application.DTO.Food.CQRS;
using MediatR;

namespace Application.DTO.Food.Mediatr
{
  public class GetByIdFoodQueryHandler : IRequestHandler<GetByIdFoodQuery, FoodDto>
  {
    private readonly IFoodBussinessLogic _bussinessLogic;

    public GetByIdFoodQueryHandler(IFoodBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<FoodDto> Handle(GetByIdFoodQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetByIdAsync(request.Id, trackChanges: false);
    }
  }
}
