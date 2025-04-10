using Application.DTO.Room;

namespace Application.BussinessLogic.Room
{
  public interface IRoomBussinessLogic
  {
    Task<List<RoomAllDto>> GetAllAsync();
    Task<Guid> CreateAsync(RoomCreateDto dto);
    Task UpdateAsync(RoomUpdateDto dto);
    Task DeleteAsync(Guid roomId);
    Task<RoomDto> GetByIdAsync(Guid id);
  }
}
