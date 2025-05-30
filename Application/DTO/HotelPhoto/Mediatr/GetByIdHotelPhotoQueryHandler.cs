using Application.BussinessLogic.HotelPhoto;
using Application.DTO.HotelPhoto.CQRS;
using MediatR;

namespace Application.DTO.HotelPhoto.Mediatr
{
  public class GetByIdHotelPhotoQueryHandler : IRequestHandler<GetByIdHotelPhotoQuery, HotelPhotoDto>
  {
    private readonly IHotelPhotoBussinessLogic _bussinessLogic;

    public GetByIdHotelPhotoQueryHandler(IHotelPhotoBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<HotelPhotoDto> Handle(GetByIdHotelPhotoQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetByIdAsync(request.Id, trackChanges: false);
    }
  }
}
