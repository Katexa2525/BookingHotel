using Application.BussinessLogic.Food;
using Application.DTO.Food.CQRS;
using MediatR;

namespace Application.DTO.Food.Mediatr
{
  public class GetAllFoodByHotelIdQueryHandler : IRequestHandler<GetAllFoodByHotelIdQuery, List<FoodDto>>
  {
    private readonly IFoodBussinessLogic _bussinessLogic;

    public GetAllFoodByHotelIdQueryHandler(IFoodBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<List<FoodDto>> Handle(GetAllFoodByHotelIdQuery request, CancellationToken cancellationToken)
    {
      return _bussinessLogic.GetByCondition(p => p.HotelId == request.HotelId, trackChanges: false);
    }
  }
}
