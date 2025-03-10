namespace Domain.Models
{
  public class Currency : BaseEntity
  {
    public IEnumerable<Price> Prices { get; set; }
  }
}
