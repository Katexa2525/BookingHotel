using Application.DTO.Room;
using System.Linq.Expressions;

namespace Application.BussinessLogic.Room
{
  public interface IRoomBussinessLogic
  {
    Task<List<RoomAllDto>> GetAllAsync(bool trackChanges);
    Task<Guid> CreateAsync(RoomCreateDto dto);
    Task UpdateAsync(RoomUpdateDto dto);
    Task DeleteAsync(Guid roomId);
    Task<RoomDto> GetByIdAsync(Guid id, bool trackChanges);
    List<RoomDto> GetByCondition(Expression<Func<Domain.Models.Room, bool>> expression, bool trackChanges);
  }
}
