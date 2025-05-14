using Application.DTO.Booking;

namespace Application.BussinessLogic.Booking
{
  public interface IBookingBussinessLogic
  {
    Task<List<BookingAllDto>> GetAllAsync(bool trackChanges);
    Task<Guid> CreateAsync(BookingCreateDto dto);
    Task DeleteAsync(Guid id);
    Task<BookingDto> GetByIdAsync(Guid id, bool trackChanges);
    Task UpdateAsync(BookingUpdateDto dto);
  }
}
