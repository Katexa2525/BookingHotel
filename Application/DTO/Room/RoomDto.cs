namespace Application.DTO.Room
{
  public class RoomDto
  {
    public Guid Id { get; set; }
    public Guid HotelId { get; set; }
    public int PeopleNumber { get; set; }
    public double Square { get; set; }
    public Guid RoomTypeId { get; set; }
  }
}
