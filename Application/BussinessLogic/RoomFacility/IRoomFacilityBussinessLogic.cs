using Application.DTO.RoomFacility;
using System.Linq.Expressions;

namespace Application.BussinessLogic.RoomFacility
{
  public interface IRoomFacilityBussinessLogic
  {
    Task<List<RoomFacilityDto>> GetAllAsync(bool trackChanges);
    Task<RoomFacilityDto> GetByIdAsync(Guid id, bool trackChanges);
    Task<Guid> CreateAsync(RoomFacilityCreateWithIdDto dto);
    Task DeleteAsync(Guid roomFacilityId);
    Task UpdateAsync(RoomFacilityDto dto);
    List<RoomFacilityDto> GetByCondition(Expression<Func<Domain.Models.RoomFacility, bool>> expression, bool trackChanges);
  }
}
