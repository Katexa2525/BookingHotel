using Application.DTO.RoomPhoto;

namespace Application.BussinessLogic.RoomPhoto
{
  public interface IRoomPhotoBussinessLogic
  {
    Task<Guid> CreateAsync(RoomPhotoCreateWithIdDto dto);
    Task DeleteAsync(Guid roomPhotoId);
  }
}
