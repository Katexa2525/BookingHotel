using Application.BussinessLogic.HotelFacility;
using Application.DTO.HotelFacility.CQRS;
using MediatR;

namespace Application.DTO.HotelFacility.Mediatr
{
  public class CreateHotelFacilityCommandHandler : IRequestHandler<CreateHotelFacilityCommand, Guid>
  {
    private readonly IHotelFacilityBussinessLogic _bussinessLogic;
    public CreateHotelFacilityCommandHandler(IHotelFacilityBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<Guid> Handle(CreateHotelFacilityCommand request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.CreateAsync(request.Dto);
    }
  }
}
