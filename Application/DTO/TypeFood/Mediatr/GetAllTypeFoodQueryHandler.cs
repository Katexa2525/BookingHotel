using Application.BussinessLogic.TypeFood;
using Application.DTO.TypeFood.CQRS;
using MediatR;

namespace Application.DTO.TypeFood.Mediatr
{
  public class GetAllTypeFoodQueryHandler : IRequestHandler<GetAllTypeFoodQuery, List<TypeFoodDto>>
  {
    private readonly ITypeFoodBussinessLogic _bussinessLogic;

    public GetAllTypeFoodQueryHandler(ITypeFoodBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<List<TypeFoodDto>> Handle(GetAllTypeFoodQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetAllAsync(trackChanges: false);
    }
  }
}
