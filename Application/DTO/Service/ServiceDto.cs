using Application.DTO.Booking;

namespace Application.DTO.Service
{
  public class ServiceDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public Guid BookingId { get; set; }
    public BookingDto Booking { get; set; }
  }
}
