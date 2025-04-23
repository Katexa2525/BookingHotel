using Application.BussinessLogic.Food;
using Application.DTO.Food.CQRS;
using MediatR;

namespace Application.DTO.Food.Mediatr
{
  public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, Guid>
  {
    private readonly IFoodBussinessLogic _bussinessLogic;
    public CreateFoodCommandHandler(IFoodBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<Guid> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.CreateAsync(request.Dto);
    }
  }
}
