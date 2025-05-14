using Application.DTO.Booking;

namespace Application.DTO.Guest
{
  public class GuestDto
  {
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PatronymicName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid BookingId { get; set; }
    public BookingDto Booking { get; set; }
  }
}
