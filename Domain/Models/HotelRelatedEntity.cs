namespace Domain.Models
{
  public abstract class HotelRelatedEntity : BaseEntity
  {
    public Guid HotelId { get; set; }
    public Hotel Hotel { get; set; }
  }
}
