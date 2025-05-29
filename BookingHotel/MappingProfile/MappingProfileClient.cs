using Application.DTO.Booking;
using Application.DTO.Food;
using Application.DTO.Hotel;
using Application.DTO.HotelFacility;
using Application.DTO.Location;
using Application.DTO.Price;
using Application.DTO.Review;
using Application.DTO.Room;
using Application.DTO.RoomFacility;
using Application.DTO.RoomPhoto;
using AutoMapper;

namespace BookingHotel.MappingProfile
{
  /// <summary>Класс настройки отображения моделей для проекта BookingHotel </summary>
  public class MappingProfileClient : Profile
  {
    public MappingProfileClient() 
    {
      // hotel
      CreateMap<HotelDto, HotelCreateDto>();
      CreateMap<HotelDto, HotelUpdateDto>();
      // room
      CreateMap<RoomDto, RoomCreateDto>();
      CreateMap<RoomDto, RoomUpdateDto>();

      CreateMap<RoomPhotoDto, RoomPhotoCreateDto>();
      CreateMap<RoomPhotoDto, RoomPhotoCreateWithIdDto>();

      CreateMap<RoomFacilityDto, RoomFacilityCreateDto>();
      CreateMap<BookingDto, BookingCreateDto>();

      CreateMap<HotelFacilityDto, HotelFacilityCreateDto>();
      CreateMap<HotelFacilityDto, HotelFacilityCreateWithIdDto>();

      CreateMap<LocationDto, LocationCreateDto>();
      CreateMap<LocationDto, LocationCreateWithIdDto>();

      CreateMap<RoomFacilityDto, RoomFacilityCreateDto>();
      CreateMap<RoomFacilityDto, RoomFacilityCreateWithIdDto>();

      CreateMap<PriceDto, PriceCreateDto>();
      CreateMap<PriceDto, PriceCreateWithIdDto>();

      CreateMap<FoodDto, FoodCreateDto>();
      CreateMap<FoodDto, FoodCreateWithIdDto>();

      CreateMap<ReviewDto, ReviewCreateDto>();
      CreateMap<ReviewDto, ReviewCreateWithIdDto>();
    }
  }
}
