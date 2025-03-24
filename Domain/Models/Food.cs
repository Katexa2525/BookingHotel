namespace Domain.Models
{
  /// <summary> Типы питания, предоставляемые отелем </summary>
  public class Food : HotelRelatedEntity
  {
    public Guid TypeFoodId { get; set; }
    public TypeFood TypeFood { get; set; }
  }
}
