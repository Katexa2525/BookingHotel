using Application.DTO.RoomPhoto;
using System.Linq.Expressions;

namespace Application.BussinessLogic.RoomPhoto
{
  public interface IRoomPhotoBussinessLogic
  {
    Task<Guid> CreateAsync(RoomPhotoCreateWithIdDto dto);
    Task DeleteAsync(Guid roomPhotoId);
    Task<RoomPhotoDto> GetByIdAsync(Guid id, bool trackChanges);
    List<RoomPhotoDto> GetByCondition(Expression<Func<Domain.Models.RoomPhoto, bool>> expression, bool trackChanges);
  }
}
