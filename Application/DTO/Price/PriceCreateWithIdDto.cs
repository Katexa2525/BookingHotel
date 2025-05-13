namespace Application.DTO.Price
{
  public class PriceCreateWithIdDto
  {
    public Guid RoomId { get; set; }
    public Guid CurrencyId { get; set; }
    /// <summary>дата начала действия цены по номеру </summary>
    public DateTime DateStart { get; set; }
    /// <summary>дата окончания действия цены по номеру</summary>
    public DateTime DateEnd { get; set; }
    public double DayPrice { get; set; }
  }
}
