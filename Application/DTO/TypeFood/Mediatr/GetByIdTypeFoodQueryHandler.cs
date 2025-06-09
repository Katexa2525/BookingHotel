using Application.BussinessLogic.TypeFood;
using Application.DTO.TypeFood.CQRS;
using MediatR;

namespace Application.DTO.TypeFood.Mediatr
{
  public class GetByIdTypeFoodQueryHandler : IRequestHandler<GetByIdTypeFoodQuery, TypeFoodDto>
  {
    private readonly ITypeFoodBussinessLogic _bussinessLogic;

    public GetByIdTypeFoodQueryHandler(ITypeFoodBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<TypeFoodDto> Handle(GetByIdTypeFoodQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetByIdAsync(request.Id, trackChanges: false);
    }
  }
}
