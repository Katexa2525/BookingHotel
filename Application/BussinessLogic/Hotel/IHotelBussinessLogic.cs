using Application.DTO.Hotel;

namespace Application.BussinessLogic.Hotel
{
  public interface IHotelBussinessLogic
  {
    Task<List<HotelAllDto>> GetAllAsync();
    Task<Guid> CreateAsync(HotelCreateDto dto);
    Task DeleteAsync(Guid hotelId);
    Task<HotelDto> GetByIdAsync(Guid id);
    Task UpdateAsync(HotelUpdateDto dto);
    Task UploadImageAsync(Guid hotelId);
  }
}
