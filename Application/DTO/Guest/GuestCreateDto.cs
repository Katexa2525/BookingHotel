namespace Application.DTO.Guest
{
  public class GuestCreateDto
  {
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? PatronymicName { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public Guid BookingId { get; set; }
  }
}
