namespace Domain.Models
{
  public class Booking : RoomRelatedEntity
  {
    public int NumberOfAdults { get; set; }
    /// <summary> Дата начала  </summary>
    public DateTime ArrivalDate { get; set; }
    /// <summary> Дата окончания </summary>
    public DateTime DepartureDate { get; set; }
    //public Guid RoomId { get; set; }
    /// <summary> Комментарий к бронированию </summary>
    public string Description { get; set; } = string.Empty;
    public ICollection<Guest> Guests { get; set; }
    public ICollection<Service> Services { get; set; }
    //public Room Room { get; set; }
  }
}
