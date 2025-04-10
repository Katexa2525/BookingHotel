using Application.BussinessLogic.GeneralMethods;
using Application.DTO.Hotel;
using Application.DTO.Room;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PriceEntity = Domain.Models.Price;
using RoomEntity = Domain.Models.Room;
using RoomFacilityEntity = Domain.Models.RoomFacility;
using RoomPhotoEntity = Domain.Models.RoomPhoto;


namespace Application.BussinessLogic.Room
{
  public class RoomBussinessLogic : IRoomBussinessLogic
  {
    private readonly IRepositoryBase<RoomEntity> _repositoryRoom;
    private readonly IRepositoryBase<PriceEntity> _repositoryPrice;
    private readonly IRepositoryBase<RoomPhotoEntity> _repositoryRoomPhoto;
    private readonly IRepositoryBase<RoomFacilityEntity> _repositoryRoomFacility;
    private readonly IGeneralBussinessLogic _generalBussinessLogic;
    private readonly IMapper _mapper;

    public RoomBussinessLogic(IRepositoryBase<RoomEntity> repositoryRoom,
                              IRepositoryBase<PriceEntity> repositoryPrice,
                              IRepositoryBase<RoomPhotoEntity> repositoryRoomPhoto,
                              IRepositoryBase<RoomFacilityEntity> repositoryRoomFacility,
                              IGeneralBussinessLogic generalBussinessLogic)
    {
      _repositoryRoom = repositoryRoom;
      _repositoryPrice = repositoryPrice;
      _repositoryRoomPhoto = repositoryRoomPhoto;
      _repositoryRoomFacility = repositoryRoomFacility;
      _generalBussinessLogic = generalBussinessLogic;
    }

    public async Task<List<RoomAllDto>> GetAllAsync()
    {
      return await _repositoryRoom.FindAll()
                                  .ProjectTo<RoomAllDto>(_mapper.ConfigurationProvider)
                                  .ToListAsync();
    }

    public async Task<RoomDto> GetByIdAsync(Guid id)
    {
      var entityDto = await _repositoryRoom.FindAll()
                           .ProjectTo<RoomDto>(_mapper.ConfigurationProvider)
                           .FirstOrDefaultAsync(x => x.Id == id);
      return entityDto;
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
      await _repositoryRoom.CreateAsync(entity);
      return entity.Id;
    }

    public async Task DeleteAsync(Guid roomId)
    {
      var room = await _repositoryRoom.FindOneAsync(x => x.Id == roomId);

      await _repositoryPrice.DeleteRangeAsync(room.Prices);
      await _repositoryRoomPhoto.DeleteRangeAsync(room.RoomPhotos);
      await _repositoryRoomFacility.DeleteRangeAsync(room.RoomFacilities);

      _repositoryRoom.Delete(room);
      await _repositoryRoom.SaveAsync();
    }

    public async Task UpdateAsync(RoomUpdateDto dto)
    {
      var entity = await _repositoryRoom.FindOneAsync(x => x.Id == dto.Id);
      if (entity == null) return;

      _mapper.Map(dto, entity);

      await _generalBussinessLogic.UpdateCollectionAsync(
            entity.Prices,
            dto.Prices,
            _repositoryPrice,
            (item, roomId) => item.RoomId = roomId,
            price => price.Id,
            dto => dto.Id
            );

      await _generalBussinessLogic.UpdateCollectionAsync(
            entity.RoomPhotos,
            dto.RoomPhotos,
            _repositoryRoomPhoto,
            (item, roomId) => item.RoomId = roomId,
            roomPhoto => roomPhoto.Id,
            dto => dto.Id
            );

      await _generalBussinessLogic.UpdateCollectionAsync(
            entity.RoomFacilities,
            dto.RoomFacilities,
            _repositoryRoomFacility,
            (item, roomId) => item.RoomId = roomId,
            roomFacility => roomFacility.Id,
            dto => dto.Id
            );

      await _repositoryRoom.SaveAsync();
    }
  }
}
