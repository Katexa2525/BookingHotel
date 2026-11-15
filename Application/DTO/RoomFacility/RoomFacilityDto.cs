namespace Application.DTO.RoomFacility
{
  public class RoomFacilityDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid RoomId { get; set; }
  }
}
