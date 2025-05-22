using Application.DTO.HotelFacility;
using System.Linq.Expressions;

namespace Application.BussinessLogic.HotelFacility
{
  public interface IHotelFacilityBussinessLogic
  {
    Task<List<HotelFacilityDto>> GetAllAsync(bool trackChanges);
    Task<HotelFacilityDto> GetByIdAsync(Guid id, bool trackChanges);
    Task<Guid> CreateAsync(HotelFacilityCreateWithIdDto dto);
    Task DeleteAsync(Guid hotelFacilityId);
    Task UpdateAsync(HotelFacilityDto dto);
    List<HotelFacilityDto> GetByCondition(Expression<Func<Domain.Models.HotelFacility, bool>> expression, bool trackChanges);
  }
}
