using Domain.Models;

namespace Application.DTO.Booking
{
  public class BookingDto
  {
    public Guid Id { get; set; }
    public int NumberOfAdults { get; set; }
    /// <summary> Дата начала  </summary>
    public DateTime ArrivalDate { get; set; }
    /// <summary> Дата окончания </summary>
    public DateTime DepartureDate { get; set; }
    /// <summary> Комментарий к бронированию </summary>
    public string Description { get; set; } = string.Empty;
    public IEnumerable<Guest> Guests { get; set; }
    public IEnumerable<Service> Services { get; set; }
  }
}
