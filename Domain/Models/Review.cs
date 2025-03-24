namespace Domain.Models
{
  /// <summary> Отзывы по отелю </summary>
  public class Review : HotelRelatedEntity
  {
    /// <summary> Дата время отзыва </summary>
    public DateTime DateTimeReview { get; set; }
    /// <summary> Главный текст отзыва </summary>
    public string Description { get; set; } = string.Empty;
    /// <summary> Кол-во звезд для отеля по отзыву. На основании звезд будет вычисляться общий рейтинг отеля </summary>
    public int Star { get; set; }
  }
}
