using Application.DTO.Hotel;
using System.Linq.Expressions;

namespace Application.BussinessLogic.Hotel
{
  public interface IHotelBussinessLogic
  {
    Task<List<HotelAllDto>> GetAllAsync(bool trackChanges);
    Task<Guid> CreateAsync(HotelCreateDto dto);
    Task DeleteAsync(Guid hotelId);
    Task<HotelDto> GetByIdAsync(Guid id, bool trackChanges);
    Task UpdateAsync(HotelUpdateDto dto);
    List<HotelDto> GetByCondition(Expression<Func<Domain.Models.Hotel, bool>> expression, bool trackChanges);
  }
}
