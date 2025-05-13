namespace Domain.Models
{
  public class Price
  {
    public Guid Id { get; set; }
    public Guid RoomId { get; set; }
    public Guid CurrencyId { get; set; }

    /// <summary>дата начала действия цены по номеру </summary>
    public DateTime DateStart { get; set; }
    /// <summary>дата окончания действия цены по номеру</summary>
    public DateTime DateEnd { get; set; }
    /// <summary> Цена за день или ночь </summary>
    public double DayPrice { get; set; }

    public Room Room { get; set; }
    public Currency Currency { get; set; }
    
  }
}
