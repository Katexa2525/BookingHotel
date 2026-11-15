using Application.BussinessLogic.Hotel;
using Application.DTO.Hotel;
using Application.DTO.Hotel.CQRS;
using MediatR;
namespace Application.DTO.Hotel.Mediatr
{
  public class GetAllHotelQueryHandler : IRequestHandler<GetAllHotelQuery, HotelListPageDto>
  {
    private readonly IHotelBussinessLogic _bussinessLogic;

    public GetAllHotelQueryHandler(IHotelBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<HotelListPageDto> Handle(GetAllHotelQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetPageAsync(request.PageNumber, request.PageSize, request.SearchTerm, request.MinRating, request.MaxRating, cancellationToken);
    }
  }
}
