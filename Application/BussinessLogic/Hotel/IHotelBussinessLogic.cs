using Application.DTO.Hotel;
using System.Linq.Expressions;

namespace Application.BussinessLogic.Hotel
{
  public interface IHotelBussinessLogic
  {
    Task<HotelListPageDto> GetPageAsync(int pageNumber, int pageSize, string? searchTerm, double? minRating, double? maxRating, CancellationToken cancellationToken);
    Task<Guid> CreateAsync(HotelCreateDto dto);
    Task DeleteAsync(Guid hotelId);
    Task<HotelDto> GetByIdAsync(Guid id, bool trackChanges);
    Task UpdateAsync(HotelUpdateDto dto);
    List<HotelDto> GetByCondition(Expression<Func<Domain.Models.Hotel, bool>> expression, bool trackChanges);
  }
}
