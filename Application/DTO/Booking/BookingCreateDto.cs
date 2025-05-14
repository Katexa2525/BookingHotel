using Application.DTO.Guest;
using Application.DTO.Service;

namespace Application.DTO.Booking
{
  public class BookingCreateDto
  {
    public string Name { get; set; } = string.Empty;
    public int NumberOfAdults { get; set; }
    /// <summary> Дата начала  </summary>
    public DateTime ArrivalDate { get; set; }
    /// <summary> Дата окончания </summary>
    public DateTime DepartureDate { get; set; }
    /// <summary> Комментарий к бронированию </summary>
    public string Description { get; set; } = string.Empty;
    public IEnumerable<GuestDto> Guests { get; set; }
    public IEnumerable<ServiceDto> Services { get; set; }
  }
}
