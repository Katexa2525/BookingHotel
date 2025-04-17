using Application.DTO.Location;

namespace Application.BussinessLogic.Location
{
  public interface ILocationBussinessLogic
  {
    Task<List<LocationDto>> GetAllAsync();
    Task<LocationDto> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(LocationCreateWithIdDto dto);
    Task DeleteAsync(Guid locationId);
    Task UpdateAsync(LocationDto dto);
  }
}
