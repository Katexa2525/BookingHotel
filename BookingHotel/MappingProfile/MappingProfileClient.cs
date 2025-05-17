using Application.DTO.Hotel;
using Application.DTO.Room;
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
    }
  }
}
