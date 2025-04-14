using Application.DTO.Price;
using Application.DTO.RoomFacility;
using Application.DTO.RoomPhoto;

namespace Application.DTO.Room
{
  public class RoomUpdateDto
  {
    public Guid Id { get; set; }
    public Guid HotelId { get; set; }
    public int PeopleNumber { get; set; }
    public double Square { get; set; }
    public Guid RoomTypeId { get; set; }
    public ICollection<PriceDto> Prices { get; set; }
    public ICollection<RoomPhotoDto> RoomPhotos { get; set; }
    public ICollection<RoomFacilityDto> RoomFacilities { get; set; }
  }
}
