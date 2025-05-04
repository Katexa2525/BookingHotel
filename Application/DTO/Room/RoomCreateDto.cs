using Application.DTO.Price;
using Application.DTO.RoomFacility;
using Application.DTO.RoomPhoto;

namespace Application.DTO.Room
{
  public class RoomCreateDto
  {
    public int PeopleNumber { get; set; }
    public double Square { get; set; }
    /// <summary> Описание номера </summary>
    public string Description { get; set; } = string.Empty;
    public Guid RoomTypeId { get; set; }
    public IEnumerable<PriceCreateDto> Prices { get; set; }
    public IEnumerable<RoomPhotoCreateDto> RoomPhotos { get; set; }
    public IEnumerable<RoomFacilityCreateDto> RoomFacilities { get; set; }
  }
}
