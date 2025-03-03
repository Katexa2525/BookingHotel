namespace Domain.Models
{
  public class Guest
  {
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PatronymicName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public Guid BookingId { get; set; }
    public Booking Booking { get; set; }
  }
}
