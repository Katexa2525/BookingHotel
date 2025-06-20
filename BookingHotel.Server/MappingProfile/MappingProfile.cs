﻿using Application.DTO.Booking;
using Application.DTO.Food;
using Application.DTO.Guest;
using Application.DTO.Hotel;
using Application.DTO.HotelFacility;
using Application.DTO.HotelPhoto;
using Application.DTO.Location;
using Application.DTO.Price;
using Application.DTO.Review;
using Application.DTO.Room;
using Application.DTO.RoomFacility;
using Application.DTO.RoomPhoto;
using Application.DTO.RoomType;
using Application.DTO.Service;
using Application.DTO.TypeFood;
using AutoMapper;
using Domain.Models;

namespace BookingHotel.Server.MappingProfile
{
  /// <summary>Класс настройки отображения моделей для проекта  BookingHotel.Server </summary>
  public class MappingProfile : Profile
  {
    public MappingProfile() 
    {
      // hotel
      CreateMap<Hotel, HotelAllDto>().ReverseMap()
                                     //.ForPath(s => s.HotelFacilities, opt => opt.Ignore())
                                     //.ForPath(s => s.HotelPhotos, opt => opt.Ignore())
                                     //.ForPath(s => s.Foods, opt => opt.Ignore())
                                     //.ForPath(s => s.Reviews, opt => opt.Ignore())
                                     //.ForPath(s => s.Rooms, opt => opt.Ignore())
                                     //.ForPath(s => s.Locations, opt => opt.Ignore())
                                     //.ForPath(s => s.HotelUsefulInfo, opt => opt.Ignore())
                                     ;

      CreateMap<Hotel, HotelCreateDto>().ReverseMap();
      CreateMap<Hotel, HotelDto>().ReverseMap();
      CreateMap<Hotel, HotelUpdateDto>().ReverseMap();

      CreateMap<HotelDto, HotelCreateDto>();
      CreateMap<HotelDto, HotelUpdateDto>();

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

      CreateMap<RoomDto, RoomUpdateDto>().ReverseMap()
        .ForPath(p => p.RoomType, opt => opt.Ignore());

      CreateMap<RoomDto, RoomCreateDto>().ReverseMap()
        .ForPath(p => p.RoomType, opt => opt.Ignore());


      CreateMap<RoomType, RoomTypeAllDto>().ReverseMap();
      CreateMap<RoomType, RoomTypeCreateDto>().ReverseMap();
      CreateMap<RoomType, RoomTypeUpdateDto>().ReverseMap();
      CreateMap<RoomType, RoomTypeDto>().ReverseMap()
                                        .ForPath(p=>p.Rooms, opt=>opt.Ignore());

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

      CreateMap<Booking, BookingAllDto>().ReverseMap();
      CreateMap<Booking, BookingCreateDto>().ReverseMap();
      CreateMap<Booking, BookingDto>().ReverseMap();
      CreateMap<Booking, BookingUpdateDto>().ReverseMap();

      CreateMap<Guest, GuestDto>().ReverseMap();
      CreateMap<Guest, GuestCreateDto>().ReverseMap();
      CreateMap<Guest, GuestUpdateDto>().ReverseMap();

      CreateMap<Review, ReviewDto>().ReverseMap();
      CreateMap<Review, ReviewCreateDto>().ReverseMap();
      CreateMap<Review, ReviewCreateWithIdDto>().ReverseMap();

      CreateMap<TypeFood, TypeFoodCreateWithIdDto>().ReverseMap();
      CreateMap<TypeFood, TypeFoodDto>().ReverseMap();

      CreateMap<Service, ServiceDto>().ReverseMap();
      

    }
  }
}
