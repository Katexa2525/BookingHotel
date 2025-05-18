using Application.DTO.RoomType;
using System.Linq.Expressions;

namespace Application.BussinessLogic.RoomType
{
  public interface IRoomTypeBussinessLogic
  {
    Task<List<RoomTypeAllDto>> GetAllAsync(bool trackChanges);
    Task<Guid> CreateAsync(RoomTypeCreateDto dto);
    Task UpdateAsync(RoomTypeUpdateDto dto);
    Task DeleteAsync(Guid roomTypeId);
    Task<RoomTypeDto> GetByIdAsync(Guid id, bool trackChanges);
    List<RoomTypeDto> GetByCondition(Expression<Func<Domain.Models.RoomType, bool>> expression, bool trackChanges);
  }
}
