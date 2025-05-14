using Application.BussinessLogic.Hotel;
using Application.DTO.Hotel.CQRS;
using MediatR;

namespace Application.DTO.Hotel.Mediatr
{
  public class GetByIdHotelQueryHandler : IRequestHandler<GetByIdHotelQuery, HotelDto>
  {
    private readonly IHotelBussinessLogic _bussinessLogic;

    public GetByIdHotelQueryHandler(IHotelBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<HotelDto> Handle(GetByIdHotelQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetByIdAsync(request.Id, trackChanges: true);
    }
  }
}
