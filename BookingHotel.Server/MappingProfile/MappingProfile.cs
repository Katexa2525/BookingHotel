using Application.DTO.Food;
using Application.DTO.Hotel;
using Application.DTO.HotelFacility;
using Application.DTO.HotelPhoto;
using Application.DTO.Location;
using Application.DTO.Price;
using Application.DTO.Room;
using Application.DTO.RoomFacility;
using Application.DTO.RoomPhoto;
using AutoMapper;
using Domain.Models;

namespace BookingHotel.Server.MappingProfile
{
  public class MappingProfile : Profile
  {
    public MappingProfile() 
    {
      // hotel
      CreateMap<Hotel, HotelAllDto>().ReverseMap();
      CreateMap<Hotel, HotelCreateDto>().ReverseMap();
      CreateMap<Hotel, HotelDto>().ReverseMap();
      CreateMap<Hotel, HotelUpdateDto>().ReverseMap();

      // hotelFacility
      CreateMap<HotelFacility, HotelFacilityCreateDto>().ReverseMap();
      CreateMap<HotelFacility, HotelFacilityCreateWithIdDto>().ReverseMap();
      CreateMap<HotelFacility, HotelFacilityDto>().ReverseMap();

      // hotelPhoto
      CreateMap<HotelPhoto, HotelPhotoCreateDto>().ReverseMap();
      CreateMap<HotelPhoto, HotelPhotoCreateWithIdDto>().ReverseMap();
      CreateMap<HotelPhoto, HotelPhotoDto>().ReverseMap();

      // room
      CreateMap<Room, RoomAllDto>().ReverseMap();
      CreateMap<Room, RoomCreateDto>().ReverseMap();
      CreateMap<Room, RoomDto>().ReverseMap();
      CreateMap<Room, RoomUpdateDto>().ReverseMap();

      // roomFacility
      CreateMap<RoomFacility, RoomFacilityCreateDto>().ReverseMap();
      CreateMap<RoomFacility, RoomFacilityCreateWithIdDto>().ReverseMap();
      CreateMap<RoomFacility, RoomFacilityDto>().ReverseMap();

      // roomPhoto
      CreateMap<RoomPhoto, RoomPhotoCreateDto>().ReverseMap();
      CreateMap<RoomPhoto, RoomPhotoCreateWithIdDto>().ReverseMap();
      CreateMap<RoomPhoto, RoomPhotoDto>().ReverseMap();

      // food
      CreateMap<Food, FoodCreateDto>().ReverseMap();
      CreateMap<Food, FoodCreateWithIdDto>().ReverseMap();
      CreateMap<Food, FoodDto>().ReverseMap();

      // location
      CreateMap<Location, LocationCreateDto>().ReverseMap();
      CreateMap<Location, LocationCreateWithIdDto>().ReverseMap();
      CreateMap<Location, LocationDto>().ReverseMap();

      // price
      CreateMap<Price, PriceCreateDto>().ReverseMap();
      CreateMap<Price, PriceCreateWithIdDto>().ReverseMap();
      CreateMap<Price, PriceDto>().ReverseMap();


    }
  }
}
