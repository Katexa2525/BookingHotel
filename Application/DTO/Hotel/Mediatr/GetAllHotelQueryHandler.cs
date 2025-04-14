using Application.BussinessLogic.Hotel;
using Application.DTO.Hotel.CQRS;
using MediatR;
namespace Application.DTO.Hotel.Mediatr
{
  public class GetAllHotelQueryHandler : IRequestHandler<GetAllHotelQuery, List<HotelAllDto>>
  {
    private readonly IHotelBussinessLogic _bussinessLogic;
    public GetAllHotelQueryHandler(IHotelBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<List<HotelAllDto>> Handle(GetAllHotelQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetAllAsync();
    }
  }
}
