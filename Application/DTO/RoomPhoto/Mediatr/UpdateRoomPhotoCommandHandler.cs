using Application.BussinessLogic.RoomPhoto;
using Application.DTO.RoomPhoto.CQRS;
using MediatR;

namespace Application.DTO.RoomPhoto.Mediatr
{
  public class UpdateRoomPhotoCommandHandler : IRequestHandler<UpdateRoomPhotoCommand, Unit>
  {
    private readonly IRoomPhotoBussinessLogic _bussinessLogic;

    public UpdateRoomPhotoCommandHandler(IRoomPhotoBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<Unit> Handle(UpdateRoomPhotoCommand request, CancellationToken cancellationToken)
    {
      await _bussinessLogic.UpdateAsync(request.Dto);
      return Unit.Value;
    }
  }
}
