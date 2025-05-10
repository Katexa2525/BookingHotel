using Application.DTO.Hotel;

namespace Application.BussinessLogic.Hotel
{
  public interface IHotelBussinessLogic
  {
    Task<List<HotelAllDto>> GetAllAsync(bool trackChanges);
    Task<Guid> CreateAsync(HotelCreateDto dto);
    Task DeleteAsync(Guid hotelId);
    Task<HotelDto> GetByIdAsync(Guid id, bool trackChanges);
    Task UpdateAsync(HotelUpdateDto dto);
  }
}
