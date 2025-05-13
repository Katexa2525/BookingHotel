using Application.DTO.Food;
using Application.DTO.HotelFacility;
using Application.DTO.HotelPhoto;
using Application.DTO.Location;
using Application.DTO.Price;
using Application.DTO.Room;
using Domain.Models;

namespace Application.DTO.Hotel
{
  public class HotelUpdateDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public double Rating { get; set; }
    public int Star { get; set; }
    public string? MainPhoto { get; set; }
    public IEnumerable<RoomDto>? Rooms { get; set; }
    public IEnumerable<FoodDto>? Foods { get; set; }
    public IEnumerable<HotelFacilityDto>? HotelFacilities { get; set; }
    public IEnumerable<HotelPhotoDto>? HotelPhotos { get; set; }
    public IEnumerable<LocationDto>? Locations { get; set; }
    //public IEnumerable<PriceDto>? Prices { get; set; }
    public IEnumerable<Review> Reviews { get; set; }
    public HotelUsefulInfo? HotelUsefulInfo { get; set; }
  }
}
