using Application.BussinessLogic.Hotel;
using Application.DTO.Hotel.CQRS;
using MediatR;

namespace Application.DTO.Hotel.Mediatr
{
  public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, Guid>
  {
    private readonly IHotelBussinessLogic _bussinessLogic;

    public CreateHotelCommandHandler (IHotelBussinessLogic bussinessLogic) 
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<Guid> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.CreateAsync(request.Dto);
    }
  }
}
