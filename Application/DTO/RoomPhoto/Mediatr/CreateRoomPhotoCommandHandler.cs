using Application.BussinessLogic.RoomPhoto;
using Application.DTO.RoomPhoto.CQRS;
using MediatR;

namespace Application.DTO.RoomPhoto.Mediatr
{
  public class CreateRoomPhotoCommandHandler : IRequestHandler<CreateRoomPhotoCommand, Guid>
  {
    private readonly IRoomPhotoBussinessLogic _bussinessLogic;
    public CreateRoomPhotoCommandHandler(IRoomPhotoBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<Guid> Handle(CreateRoomPhotoCommand request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.CreateAsync(request.Dto);
    }
  }
}
