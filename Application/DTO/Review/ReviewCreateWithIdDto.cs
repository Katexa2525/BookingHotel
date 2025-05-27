namespace Application.DTO.Review
{
  public class ReviewCreateWithIdDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    /// <summary> Дата время отзыва </summary>
    public DateTime DateTimeReview { get; set; }
    /// <summary> Главный текст отзыва </summary>
    public string Description { get; set; } = string.Empty;
    /// <summary> Кол-во звезд для отеля по отзыву. На основании звезд будет вычисляться общий рейтинг отеля </summary>
    public int Star { get; set; }
    public Guid HotelId { get; set; }
  }
}
