using Application.DTO.Room;

namespace Application.BussinessLogic.Room
{
  public interface IRoomBussinessLogic
  {
    Task<List<RoomDto>> GetAllAsync();
    Task<Guid> CreateAsync(RoomCreateDto dto);
  }
}
