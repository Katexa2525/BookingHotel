using Application.BussinessLogic.GeneralMethods;
using Application.DTO.Hotel;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using HotelEntity = Domain.Models.Hotel;

namespace Application.BussinessLogic.Hotel
{
  public class HotelBussinessLogic : IHotelBussinessLogic
  {
    private readonly IGeneralBussinessLogic _generalBussinessLogic;
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;


    public HotelBussinessLogic(IGeneralBussinessLogic generalBussinessLogic,
                               IMapper mapper, IRepositoryManager repositoryManager)
    {
      _generalBussinessLogic = generalBussinessLogic;
      _mapper = mapper;
      _repositoryManager = repositoryManager;
    }

    public async Task<HotelListPageDto> GetPageAsync(int pageNumber, int pageSize, string? searchTerm, double? minRating, double? maxRating, CancellationToken cancellationToken)
    {
      if (pageNumber < 1)
        throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be positive.");
      if (pageSize is < 1 or > 100)
        throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be between 1 and 100.");
      if (pageNumber > int.MaxValue / pageSize)
        throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number is too large.");

      var query = _repositoryManager.HotelRepository.GetHotelListQuery(trackChanges: false);
      if (!string.IsNullOrWhiteSpace(searchTerm))
        query = query.Where(h => h.Name.Contains(searchTerm) || h.Location.Contains(searchTerm));
      if (minRating.HasValue)
        query = query.Where(h => h.Rating >= minRating.Value);
      if (maxRating.HasValue)
        query = query.Where(h => h.Rating <= maxRating.Value);

      var totalCount = await query.CountAsync(cancellationToken);
      var hotels = await query
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .Select(h => new HotelListDto
        {
          Id = h.Id,
          Name = h.Name,
          Description = h.Description ?? string.Empty,
          Location = h.Location,
          Rating = h.Rating,
          Star = h.Star,
          MainPhoto = h.MainPhoto,
          Arrival = h.Arrival ?? string.Empty,
          Departure = h.Departure ?? string.Empty,
          Latitude = h.Latitude,
          Longitude = h.Longitude,
          FacilityNames = h.HotelFacilities.Select(facility => facility.Name).ToList(),
          FoodNames = h.Foods.Select(food => food.Name).ToList(),
          NearbyLocationNames = h.Locations.Select(location => location.Name).ToList()
        })
        .ToListAsync(cancellationToken);

      return new HotelListPageDto
      {
        Hotels = hotels,
        PageNumber = pageNumber,
        PageSize = pageSize,
        TotalCount = totalCount
      };
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
      //foreach (var price in entity.Prices)
      //  price.HotelId = entity.Id;

      await _repositoryManager.HotelRepository.CreateEntityAsync(entity);
      await _repositoryManager.SaveAsync();
      return entity.Id;
    }

    public async Task<HotelDto> GetByIdAsync(Guid id, bool trackChanges)
    {
      //var hotel = await _repositoryManager.HotelRepository.GetOneAsync(x => x.Id == id, trackChanges);
      var hotel = _repositoryManager.HotelRepository.GetByCondition(x => x.Id == id, trackChanges).FirstOrDefault();
      if (hotel is null)
        throw new KeyNotFoundException($"Hotel '{id}' was not found.");

      return _mapper.Map<HotelDto>(hotel);
    }

    public async Task DeleteAsync(Guid hotelId)
    {
      var hotel = await _repositoryManager.HotelRepository.GetOneAsync(x => x.Id == hotelId, trackChanges: true);
      //var hotel = _repositoryManager.HotelRepository.GetByCondition(x => x.Id == hotelId, trackChanges: false).FirstOrDefault();

      if (hotel is not null)
      {
        if (hotel.Rooms is not null)
          await _repositoryManager.RoomRepository.DeleteEntityRangeAsync(hotel.Rooms);
        if (hotel.Foods is not null)
          await _repositoryManager.FoodRepository.DeleteEntityRangeAsync(hotel.Foods);
        if (hotel.HotelFacilities is not null)
          await _repositoryManager.HotelFacilityRepository.DeleteEntityRangeAsync(hotel.HotelFacilities);
        if (hotel.HotelPhotos is not null)
          await _repositoryManager.HotelPhotoRepository.DeleteEntityRangeAsync(hotel.HotelPhotos);
        if (hotel.Locations is not null)
          await _repositoryManager.LocationRepository.DeleteEntityRangeAsync(hotel.Locations);
        //if (hotel.Prices is not null)
        //  await _repositoryManager.PriceRepository.DeleteEntityRangeAsync(hotel.Prices);
        if (hotel.Reviews is not null)
          await _repositoryManager.ReviewRepository.DeleteEntityRangeAsync(hotel.Reviews);

        _repositoryManager.HotelRepository.DeleteEntity(hotel);
        await _repositoryManager.SaveAsync();
      }
    }

    public async Task UpdateAsync(HotelUpdateDto dto)
    {
      //var entity = await _repositoryHotel.FindOneAsync(x => x.Id == dto.Id);

      var entity = await _repositoryManager.HotelRepository.GetOneAsync(x => x.Id == dto.Id, trackChanges: true);
      if (entity == null) return;

      _mapper.Map(dto, entity);

      _repositoryManager.HotelRepository.UpdateEntity(entity);
      await _repositoryManager.SaveAsync();

      /*
      await _generalBussinessLogic.UpdateCollectionAsync(
            entity.Rooms,
            dto.Rooms,
            _repositoryRoom,
           // null,
            (item, hotelId) => item.HotelId = hotelId,
            room => room.Id,
            dto => dto.Id
            );

      await _generalBussinessLogic.UpdateCollectionAsync(
            entity.Foods,
            dto.Foods,
            _repositoryFood,
            (item, hotelId) => item.HotelId = hotelId,
            food => food.Id,
            dto => dto.Id
            );

      await _generalBussinessLogic.UpdateCollectionAsync(
            entity.HotelFacilities,
            dto.HotelFacilities,
            _repositoryFacility,
            (item, hotelId) => item.HotelId = hotelId,
            hotelFacility => hotelFacility.Id,
            dto => dto.Id
            );

      await _generalBussinessLogic.UpdateCollectionAsync(
            entity.HotelPhotos,
            dto.HotelPhotos,
            _repositoryPhoto,
            (item, hotelId) => item.HotelId = hotelId,
            hotelPhoto => hotelPhoto.Id,
            dto => dto.Id
            );

      await _generalBussinessLogic.UpdateCollectionAsync(
            entity.Locations,
            dto.Locations,
            _repositoryLocation,
            (item, hotelId) => item.HotelId = hotelId,
            location => location.Id,
            dto => dto.Id
            );

      await _generalBussinessLogic.UpdateCollectionAsync(
            entity.Reviews,
            dto.Reviews,
            _repositoryReview,
            (item, hotelId) => item.HotelId = hotelId,
            location => location.Id,
            dto => dto.Id
            );
      */

      //await _repositoryHotel.SaveAsync();
    }

    public List<HotelDto> GetByCondition(Expression<Func<HotelEntity, bool>> expression, bool trackChanges)
    {
      return _repositoryManager.HotelRepository.GetByCondition(expression, trackChanges).AsQueryable()
                                   .ProjectTo<HotelDto>(_mapper.ConfigurationProvider)
                                   .ToList();
    }
  }
}
