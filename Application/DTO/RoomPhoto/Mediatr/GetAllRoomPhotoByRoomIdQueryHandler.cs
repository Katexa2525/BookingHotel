using Application.BussinessLogic.RoomPhoto;
using Application.DTO.RoomPhoto.CQRS;
using MediatR;

namespace Application.DTO.RoomPhoto.Mediatr
{
  public class GetAllRoomPhotoByRoomIdQueryHandler : IRequestHandler<GetAllRoomPhotoByRoomIdQuery, List<RoomPhotoDto>>
  {
    private readonly IRoomPhotoBussinessLogic _bussinessLogic;

    public GetAllRoomPhotoByRoomIdQueryHandler(IRoomPhotoBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<List<RoomPhotoDto>> Handle(GetAllRoomPhotoByRoomIdQuery request, CancellationToken cancellationToken)
    {
      return _bussinessLogic.GetByCondition(p => p.RoomId == request.RoomId, trackChanges: false);
    }
  }
}
