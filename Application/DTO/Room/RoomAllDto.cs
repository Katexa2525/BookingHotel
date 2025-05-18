namespace Application.DTO.Room
{
  public class RoomAllDto
  {
    public Guid Id { get; set; }
    public Guid HotelId { get; set; }
    public int PeopleNumber { get; set; }
    public double Square { get; set; }
    /// <summary> Описание номера </summary>
    public string Description { get; set; } = string.Empty;
    /// <summary> Основное фото отеля </summary>
    public string? MainPhoto { get; set; } = string.Empty;
    public Guid RoomTypeId { get; set; }
  }
}
