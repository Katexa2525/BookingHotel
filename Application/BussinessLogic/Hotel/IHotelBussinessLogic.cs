using Application.DTO.Hotel;

namespace Application.BussinessLogic.Hotel
{
    public interface IHotelBussinessLogic
    {
      Task<List<HotelDto>> GetAllAsync();
      Task<Guid> CreateAsync(HotelCreateDto dto);
    }
}
