namespace Domain.Models
{
  public class Currency : BaseEntity
  {
    public ICollection<Price> Prices { get; set; }
  }
}
