﻿using Application.DTO.Food;
using Application.DTO.HotelFacility;
using Application.DTO.HotelPhoto;
using Application.DTO.Location;
using Application.DTO.Price;
using Application.DTO.Room;

namespace Application.DTO.Hotel
{
  public class HotelCreateDto
  {
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public double Rating { get; set; }
    public int Star { get; set; }
    public string? MainPhoto { get; set; }
    public IEnumerable<RoomCreateDto> Rooms { get; set; }
    public IEnumerable<FoodCreateDto> Foods { get; set; }
    public IEnumerable<HotelFacilityCreateDto> HotelFacilities { get; set; }
    public IEnumerable<HotelPhotoCreateDto> HotelPhotos { get; set; }
    public IEnumerable<LocationCreateDto> Locations { get; set; }
    public IEnumerable<PriceCreateDto> Prices { get; set; }
  }
}
