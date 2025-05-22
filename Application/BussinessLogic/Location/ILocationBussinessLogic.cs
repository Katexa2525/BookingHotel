using Application.DTO.Location;
using System.Linq.Expressions;

namespace Application.BussinessLogic.Location
{
  public interface ILocationBussinessLogic
  {
    Task<List<LocationDto>> GetAllAsync(bool trackChanges);
    Task<LocationDto> GetByIdAsync(Guid id, bool trackChanges);
    Task<Guid> CreateAsync(LocationCreateWithIdDto dto);
    Task DeleteAsync(Guid locationId);
    Task UpdateAsync(LocationDto dto);
    List<LocationDto> GetByCondition(Expression<Func<Domain.Models.Location, bool>> expression, bool trackChanges);
  }
}
