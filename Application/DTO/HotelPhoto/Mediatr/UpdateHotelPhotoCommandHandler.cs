using Application.BussinessLogic.HotelPhoto;
using Application.DTO.HotelPhoto.CQRS;
using MediatR;

namespace Application.DTO.HotelPhoto.Mediatr
{
  public class UpdateHotelPhotoCommandHandler : IRequestHandler<UpdateHotelPhotoCommand, Unit>
  {
    private readonly IHotelPhotoBussinessLogic _bussinessLogic;

    public UpdateHotelPhotoCommandHandler(IHotelPhotoBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<Unit> Handle(UpdateHotelPhotoCommand request, CancellationToken cancellationToken)
    {
      await _bussinessLogic.UpdateAsync(request.Dto);
      return Unit.Value;
    }
  }
}
