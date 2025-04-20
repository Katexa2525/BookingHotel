using Application.BussinessLogic.GeneralMethods;
using Application.DTO.Hotel;
using Application.DTO.Room;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using FoodEntity = Domain.Models.Food;
using HotelEntity = Domain.Models.Hotel;
using HotelFacilityEntity = Domain.Models.HotelFacility;
using HotelPhotoEntity = Domain.Models.HotelPhoto;
using LocationEntity = Domain.Models.Location;
using PriceEntity = Domain.Models.Price;
using ReviewEntity = Domain.Models.Review;
using RoomEntity = Domain.Models.Room;

namespace Application.BussinessLogic.Hotel
{
  public class HotelBussinessLogic : IHotelBussinessLogic
  {
    //private readonly IRepositoryBase<HotelEntity> _repositoryHotel;
    //private readonly IRepositoryBase<RoomEntity> _repositoryRoom;
    //private readonly IRepositoryBase<FoodEntity> _repositoryFood;
    //private readonly IRepositoryBase<HotelFacilityEntity> _repositoryHotelFacility;
    //private readonly IRepositoryBase<HotelPhotoEntity> _repositoryHotelPhoto;
    //private readonly IRepositoryBase<LocationEntity> _repositoryLocation;
    //private readonly IRepositoryBase<PriceEntity> _repositoryPrice;
    //private readonly IRepositoryBase<ReviewEntity> _repositoryReview;
    private readonly IGeneralBussinessLogic _generalBussinessLogic;
    private readonly IRepositoryManager _repositoryManager;

    private readonly IMapper _mapper;

    public HotelBussinessLogic(/*IRepositoryBase<HotelEntity> repositoryHotel,
                               IRepositoryBase<RoomEntity> repositoryRoom,
                               IRepositoryBase<FoodEntity> repositoryFood,
                               IRepositoryBase<HotelFacilityEntity> repositoryHotelFacility,
                               IRepositoryBase<HotelPhotoEntity> repositoryHotelPhoto,
                               IRepositoryBase<LocationEntity> repositoryLocation,
                               IRepositoryBase<PriceEntity> repositoryPrice,
                               IRepositoryBase<ReviewEntity> repositoryReview,*/
                               IGeneralBussinessLogic generalBussinessLogic,
                               IMapper mapper,
                               IRepositoryManager repositoryManager)
    {
      //_repositoryHotel = repositoryHotel;
      //_repositoryRoom = repositoryRoom;
      //_repositoryFood = repositoryFood;
      //_repositoryHotelFacility = repositoryHotelFacility;
      //_repositoryHotelPhoto = repositoryHotelPhoto;
      //_repositoryLocation = repositoryLocation;
      //_repositoryPrice = repositoryPrice;
      //_repositoryReview = repositoryReview;
      _generalBussinessLogic = generalBussinessLogic;
      _mapper = mapper;
      _repositoryManager = repositoryManager;
    }

    public async Task<List<HotelAllDto>> GetAllAsync()
    {
      //return await _repositoryHotel.FindAll()
      //                             .ProjectTo<HotelAllDto>(_mapper.ConfigurationProvider)
      //                             .ToListAsync();

      //var listDB = await _repositoryManager.HotelRepository.GetAllAsync(trackChanges: true);
      //var listReturn = listDB.AsQueryable().ProjectTo<HotelAllDto>(_mapper.ConfigurationProvider);

      //return null;

      return await _repositoryManager.HotelRepository.GetAll(trackChanges: true).AsQueryable()
                                  .ProjectTo<HotelAllDto>(_mapper.ConfigurationProvider)
                                  .ToListAsync();
    }

    public async Task<Guid> CreateAsync(HotelCreateDto dto)
    {
      var entity = _mapper.Map<HotelEntity>(dto);
      entity.Id = Guid.NewGuid();
      foreach (var room in entity.Rooms)
        room.HotelId = entity.Id;
      foreach (var food in entity.Foods)
        food.HotelId = entity.Id;
      foreach (var hotelFacility in entity.HotelFacilities)
        hotelFacility.HotelId = entity.Id;
      foreach (var hotelPhoto in entity.HotelPhotos)
        hotelPhoto.HotelId = entity.Id;
      foreach (var location in entity.Locations)
        location.HotelId = entity.Id;
      foreach (var price in entity.Prices)
        price.HotelId = entity.Id;
      //await _repositoryHotel.CreateAsync(entity);
      await _repositoryManager.HotelRepository.CreateEntityAsync(entity);
      return entity.Id;
    }

    public async Task<HotelDto> GetByIdAsync(Guid id)
    {
      //var entityDto = await _repositoryHotel.FindAll()
      //                     .ProjectTo<HotelDto>(_mapper.ConfigurationProvider)
      //                     .FirstOrDefaultAsync(x => x.Id == id);

      var entityDto = await _repositoryManager.HotelRepository.GetByCondition(x => x.Id == id, trackChanges: true)
                           .AsQueryable().ProjectTo<HotelDto>(_mapper.ConfigurationProvider).FirstAsync();
      return entityDto;
    }

    public async Task DeleteAsync(Guid hotelId)
    {
      //var hotel = await _repositoryHotel.FindOneAsync(x => x.Id == hotelId);
      var hotel = await _repositoryManager.HotelRepository.GetOneAsync(x => x.Id == hotelId);

      //await _repositoryRoom.DeleteRangeAsync(hotel.Rooms);
      //await _repositoryFood.DeleteRangeAsync(hotel.Foods);
      //await _repositoryHotelFacility.DeleteRangeAsync(hotel.HotelFacilities);
      //await _repositoryHotelPhoto.DeleteRangeAsync(hotel.HotelPhotos);
      //await _repositoryLocation.DeleteRangeAsync(hotel.Locations);
      //await _repositoryPrice.DeleteRangeAsync(hotel.Prices);
      //await _repositoryReview.DeleteRangeAsync(hotel.Reviews);

      await _repositoryManager.RoomRepository.DeleteEntityRangeAsync(hotel.Rooms);
      await _repositoryManager.FoodRepository.DeleteEntityRangeAsync(hotel.Foods);
      await _repositoryManager.HotelFacilityRepository.DeleteEntityRangeAsync(hotel.HotelFacilities);
      await _repositoryManager.HotelPhotoRepository.DeleteEntityRangeAsync(hotel.HotelPhotos);
      await _repositoryManager.LocationRepository.DeleteEntityRangeAsync(hotel.Locations);
      await _repositoryManager.PriceRepository.DeleteEntityRangeAsync(hotel.Prices);
      await _repositoryManager.ReviewRepository.DeleteEntityRangeAsync(hotel.Reviews);

      //_repositoryHotel.Delete(hotel);
      //await _repositoryRoom.SaveAsync();

      _repositoryManager.HotelRepository.DeleteEntity(hotel);
      await _repositoryManager.SaveAsync();
    }

    public async Task UpdateAsync(HotelUpdateDto dto)
    {
      //var entity = await _repositoryHotel.FindOneAsync(x => x.Id == dto.Id);
      var entity = await _repositoryManager.HotelRepository.GetOneAsync(x => x.Id == dto.Id);
      if (entity == null) return;

      _mapper.Map(dto, entity);

      await _generalBussinessLogic.UpdateCollectionAsync(
            entity.Prices,
            dto.Prices,
            //_repositoryPrice,
            null,
            (item, hotelId) => item.HotelId = hotelId,
            price => price.Id,
            dto => dto.Id
            );

      await _generalBussinessLogic.UpdateCollectionAsync(
            entity.Rooms,
            dto.Rooms,
            //_repositoryRoom,
            null,
            (item, hotelId) => item.HotelId = hotelId,
            room => room.Id,
            dto => dto.Id
            );

      await _generalBussinessLogic.UpdateCollectionAsync(
            entity.Foods,
            dto.Foods,
            //_repositoryFood,
            null,
            (item, hotelId) => item.HotelId = hotelId,
            food => food.Id,
            dto => dto.Id
            );

      await _generalBussinessLogic.UpdateCollectionAsync(
            entity.HotelFacilities,
            dto.HotelFacilities,
            //_repositoryHotelFacility,
            null,
            (item, hotelId) => item.HotelId = hotelId,
            hotelFacility => hotelFacility.Id,
            dto => dto.Id
            );

      await _generalBussinessLogic.UpdateCollectionAsync(
            entity.HotelPhotos,
            dto.HotelPhotos,
            //_repositoryHotelPhoto,
            null,
            (item, hotelId) => item.HotelId = hotelId,
            hotelPhoto => hotelPhoto.Id,
            dto => dto.Id
            );

      await _generalBussinessLogic.UpdateCollectionAsync(
            entity.Locations,
            dto.Locations,
            //_repositoryLocation,
            null,
            (item, hotelId) => item.HotelId = hotelId,
            location => location.Id,
            dto => dto.Id
            );

      //await _repositoryHotel.SaveAsync();
      await _repositoryManager.SaveAsync();
    }
  }
}
