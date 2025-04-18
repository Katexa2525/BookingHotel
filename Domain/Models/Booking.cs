namespace Domain.Models
{
  public class Booking
  {
    public Guid Id { get; set; }
    public int NumberOfAdults { get; set; }
    public DateTime RaceDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public ICollection<Guest> Guests { get; set; }
    public ICollection<Service> Services { get; set; }
  }
}
