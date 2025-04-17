using Application.DTO.HotelFacility;

namespace Application.BussinessLogic.HotelFacility
{
  public interface IHotelFacilityBussinessLogic
  {
    Task<List<HotelFacilityDto>> GetAllAsync();
    Task<HotelFacilityDto> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(HotelFacilityCreateWithIdDto dto);
    Task DeleteAsync(Guid hotelFacilityId);
    Task UpdateAsync(HotelFacilityDto dto);
  }
}
