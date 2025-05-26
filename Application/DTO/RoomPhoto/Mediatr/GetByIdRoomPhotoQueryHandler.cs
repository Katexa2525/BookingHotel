using Application.BussinessLogic.RoomPhoto;
using Application.DTO.RoomPhoto.CQRS;
using MediatR;

namespace Application.DTO.RoomPhoto.Mediatr
{
  public class GetByIdRoomPhotoQueryHandler : IRequestHandler<GetByIdRoomPhotoQuery, RoomPhotoDto>
  {
    private readonly IRoomPhotoBussinessLogic _bussinessLogic;

    public GetByIdRoomPhotoQueryHandler(IRoomPhotoBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<RoomPhotoDto> Handle(GetByIdRoomPhotoQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetByIdAsync(request.Id, trackChanges: false);
    }
  }
}
