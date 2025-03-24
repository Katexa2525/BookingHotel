namespace Domain.Models
{
  /// <summary> Типы питания -  "Завтрак",  "Полупансион" , "Завтрак, обед и ужин" , "Всё включено" , "Без питания" </summary>
  public class TypeFood : BaseEntity
  {
    public ICollection<Food> Foods { get; set; } = Array.Empty<Food>();
  }
}
