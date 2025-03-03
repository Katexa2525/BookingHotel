namespace Domain.Models
{
  public class Service : BaseEntity
  {
    public double Price { get; set; }
    public Guid BookingId { get; set; }
    public Booking Booking { get; set; }
  }
}
