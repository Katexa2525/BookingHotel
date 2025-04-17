using Application.BussinessLogic.HotelPhoto;
using Application.DTO.HotelPhoto.CQRS;
using MediatR;

namespace Application.DTO.HotelPhoto.Mediatr
{
  public class DeleteHotelPhotoCommandHandler : IRequestHandler<DeleteHotelPhotoCommand, Unit>
  {
    private readonly IHotelPhotoBussinessLogic _bussinessLogic;
    public DeleteHotelPhotoCommandHandler(IHotelPhotoBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<Unit> Handle(DeleteHotelPhotoCommand request, CancellationToken cancellationToken)
    {
      await _bussinessLogic.DeleteAsync(request.HotelPhotoId);
      return Unit.Value;
    }
  }
}
