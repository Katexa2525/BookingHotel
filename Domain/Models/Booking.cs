namespace Domain.Models
{
  public class Booking : RoomRelatedEntity
  {
    public int NumberOfAdults { get; set; }
    public int NumberOfChilds { get; set; }
    /// <summary> Дата начала  </summary>
    public DateTime ArrivalDate { get; set; }
    /// <summary> Дата окончания </summary>
    public DateTime DepartureDate { get; set; }
    /// <summary> Комментарий к бронированию </summary>
    public string? Description { get; set; } = string.Empty;
    /// <summary> id пользователя из Keycloak </summary>
    public string? UserId { get; set; } = string.Empty;
    public ICollection<Guest> Guests { get; set; }
    public ICollection<Service> Services { get; set; }
  }
}
