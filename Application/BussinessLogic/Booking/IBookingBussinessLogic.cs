using Application.DTO.Booking;
using System.Linq.Expressions;

namespace Application.BussinessLogic.Booking
{
  public interface IBookingBussinessLogic
  {
    Task<List<BookingAllDto>> GetAllAsync(bool trackChanges);
    Task<Guid> CreateAsync(BookingCreateDto dto);
    Task DeleteAsync(Guid id);
    Task<BookingDto> GetByIdAsync(Guid id, bool trackChanges);
    Task UpdateAsync(BookingUpdateDto dto);
    List<BookingDto> GetByCondition(Expression<Func<Domain.Models.Booking, bool>> expression, bool trackChanges);
  }
}
