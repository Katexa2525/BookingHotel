using Application.BussinessLogic.HotelPhoto;
using Application.DTO.HotelPhoto.CQRS;
using MediatR;

namespace Application.DTO.HotelPhoto.Mediatr
{
  public class GetAllHotelPhotoByHotelIdQueryHandler : IRequestHandler<GetAllHotelPhotoByHotelIdQuery, List<HotelPhotoDto>>
  {
    private readonly IHotelPhotoBussinessLogic _bussinessLogic;

    public GetAllHotelPhotoByHotelIdQueryHandler(IHotelPhotoBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<List<HotelPhotoDto>> Handle(GetAllHotelPhotoByHotelIdQuery request, CancellationToken cancellationToken)
    {
      return _bussinessLogic.GetByCondition(p => p.HotelId == request.HotelId, trackChanges: false);
    }
  }
}
