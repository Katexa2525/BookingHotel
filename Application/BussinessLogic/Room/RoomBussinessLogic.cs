using Application.DTO.Hotel;
using Application.DTO.Room;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RoomEntity = Domain.Models.Room;
using PriceEntity = Domain.Models.Price;
using RoomPhotoEntity = Domain.Models.RoomPhoto;
using RoomFacilityEntity = Domain.Models.RoomFacility;


namespace Application.BussinessLogic.Room
{
  public class RoomBussinessLogic : IRoomBussinessLogic
  {
    private readonly IRepositoryBase<RoomEntity> _repositoryRoom;
    private readonly IRepositoryBase<PriceEntity> _repositoryPrice;
    private readonly IRepositoryBase<RoomPhotoEntity> _repositoryRoomPhoto;
    private readonly IRepositoryBase<RoomFacilityEntity> _repositoryRoomFacility;
    private readonly IMapper _mapper;

    public RoomBussinessLogic(IRepositoryBase<RoomEntity> repositoryRoom,
                              IRepositoryBase<PriceEntity> repositoryPrice,
                              IRepositoryBase<RoomPhotoEntity> repositoryRoomPhoto,
                              IRepositoryBase<RoomFacilityEntity> repositoryRoomFacility)
    {
      _repositoryRoom = repositoryRoom;
      _repositoryPrice = repositoryPrice;
      _repositoryRoomPhoto = repositoryRoomPhoto;
      _repositoryRoomFacility = repositoryRoomFacility;
    }

    public async Task<List<RoomDto>> GetAllAsync()
    {
      return await _repositoryRoom.FindAll().ProjectTo<RoomDto>(_mapper.ConfigurationProvider)
                                        .ToListAsync();
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
  }
}
