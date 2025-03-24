namespace Domain.Models
{
  /// <summary>Класс для хранения полезной информации об отеле. Храниться будет как Name-Value, например: Время заезда-15:00 </summary>
  public class HotelUsefulInfo : HotelRelatedEntity
  {
    public string Value { get; set; } = string.Empty;
  }
}
