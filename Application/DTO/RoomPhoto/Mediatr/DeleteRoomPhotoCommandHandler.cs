using Application.BussinessLogic.RoomPhoto;
using Application.DTO.RoomPhoto.CQRS;
using MediatR;

namespace Application.DTO.RoomPhoto.Mediatr
{
  public class DeleteRoomPhotoCommandHandler : IRequestHandler<DeleteRoomPhotoCommand, Unit>
  {
    private readonly IRoomPhotoBussinessLogic _bussinessLogic;
    public DeleteRoomPhotoCommandHandler(IRoomPhotoBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<Unit> Handle(DeleteRoomPhotoCommand request, CancellationToken cancellationToken)
    {
      await _bussinessLogic.DeleteAsync(request.RoomPhotoId);
      return Unit.Value;
    }
  }
}
