using Application.BussinessLogic.GeneralMethods;
using Application.DTO.Room;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RoomEntity = Domain.Models.Room;


namespace Application.BussinessLogic.Room
{
  public class RoomBussinessLogic : IRoomBussinessLogic
  {
    private readonly IGeneralBussinessLogic _generalBussinessLogic;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repositoryManager;

    public RoomBussinessLogic(IGeneralBussinessLogic generalBussinessLogic, IMapper mapper,
                              IRepositoryManager repositoryManager)
                                              
    {
      _generalBussinessLogic = generalBussinessLogic;
      _mapper = mapper;
      _repositoryManager = repositoryManager;
    }

    public async Task<List<RoomAllDto>> GetAllAsync()
    {
      return await _repositoryManager.RoomRepository.GetAll(trackChanges: true).AsQueryable()
                                  .ProjectTo<RoomAllDto>(_mapper.ConfigurationProvider)
                                  .ToListAsync();
    }

    public async Task<RoomDto> GetByIdAsync(Guid id)
    {
      var entityDto = await _repositoryManager.RoomRepository.GetByCondition(x => x.Id == id, trackChanges: true)
                           .AsQueryable().ProjectTo<RoomDto>(_mapper.ConfigurationProvider).FirstAsync();

      return entityDto;
    }

    public List<RoomDto> GetByCondition(Expression<Func<Domain.Models.Room, bool>> expression, bool trackChanges)
    {
      return _repositoryManager.RoomRepository.GetByCondition(expression, trackChanges: true).AsQueryable()
                                  .ProjectTo<RoomDto>(_mapper.ConfigurationProvider)
                                  .ToList();
    }

    public async Task<Guid> CreateAsync(RoomCreateDto dto)
    {
      var entity = _mapper.Map<RoomEntity>(dto);
      entity.Id = Guid.NewGuid();
      foreach (var price in entity.Prices)
        price.RoomId = entity.Id;
      foreach (var roomPhotos in entity.RoomPhotos)
        roomPhotos.RoomId = entity.Id;
      foreach (var roomFacility in entity.RoomFacilities)
        roomFacility.RoomId = entity.Id;
      //await _repositoryRoom.CreateAsync(entity);
      await _repositoryManager.RoomRepository.CreateEntityAsync(entity);
      return entity.Id;
    }

    public async Task DeleteAsync(Guid roomId)
    {
      var room = await _repositoryManager.RoomRepository.GetOneAsync(x => x.Id == roomId);

      await _repositoryManager.PriceRepository.DeleteEntityRangeAsync(room.Prices);
      await _repositoryManager.RoomPhotoRepository.DeleteEntityRangeAsync(room.RoomPhotos);
      await _repositoryManager.RoomFacilityRepository.DeleteEntityRangeAsync(room.RoomFacilities);

      _repositoryManager.RoomRepository.DeleteEntity(room);
      await _repositoryManager.SaveAsync();
    }

    public async Task UpdateAsync(RoomUpdateDto dto)
    {
      //var entity = await _repositoryRoom.FindOneAsync(x => x.Id == dto.Id);
      var entity = await _repositoryManager.RoomRepository.GetOneAsync(x => x.Id == dto.Id);
      if (entity == null) return;

      _mapper.Map(dto, entity);

      await _generalBussinessLogic.UpdateCollectionAsync(
            entity.Prices,
            dto.Prices,
            //_repositoryPrice,
            null,
            (item, roomId) => item.RoomId = roomId,
            price => price.Id,
            dto => dto.Id
            );

      await _generalBussinessLogic.UpdateCollectionAsync(
            entity.RoomPhotos,
            dto.RoomPhotos,
            //_repositoryRoomPhoto,
            null,
            (item, roomId) => item.RoomId = roomId,
            roomPhoto => roomPhoto.Id,
            dto => dto.Id
            );

      await _generalBussinessLogic.UpdateCollectionAsync(
            entity.RoomFacilities,
            dto.RoomFacilities,
            //_repositoryRoomFacility,
            null,
            (item, roomId) => item.RoomId = roomId,
            roomFacility => roomFacility.Id,
            dto => dto.Id
            );

      await _repositoryManager.SaveAsync();
    }
    
  }
}
