using Application.DTO.Guest;

namespace Application.BussinessLogic.Guest
{
  public interface IGuestBussinessLogic
  {
    Task<List<GuestAllDto>> GetAllAsync(bool trackChanges);
    Task<Guid> CreateAsync(GuestCreateDto dto);
    Task DeleteAsync(Guid id);
    Task<GuestDto> GetByIdAsync(Guid id, bool trackChanges);
    Task UpdateAsync(GuestUpdateDto dto);
  }
}
