using Application.DTO.Booking;
using Application.DTO.Hotel;
using Application.DTO.HotelFacility;
using Application.DTO.Price;
using Application.DTO.Room;
using Application.DTO.RoomFacility;
using Application.DTO.RoomPhoto;
using AutoMapper;
using Domain.Models;

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

      CreateMap<PriceDto, PriceCreateDto>();
      CreateMap<RoomPhotoDto, RoomPhotoCreateDto>();
      CreateMap<RoomFacilityDto, RoomFacilityCreateDto>();
      CreateMap<BookingDto, BookingCreateDto>();

      CreateMap<HotelFacilityDto, HotelFacilityCreateDto>();
      CreateMap<HotelFacilityDto, HotelFacilityCreateWithIdDto>();
      CreateMap<HotelFacilityDto, HotelFacilityDto>();
    }
  }
}
