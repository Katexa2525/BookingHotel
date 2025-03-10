using Application.BussinessLogic.Hotel;
using Application.DTO.Hotel.CQRS;
using MediatR;
namespace Application.DTO.Hotel.Mediatr
{
  public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<HotelDto>>
  {
    private readonly IHotelBussinessLogic _bussinessLogic;
    public GetAllQueryHandler(IHotelBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<List<HotelDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetAllAsync();
    }
  }
}
