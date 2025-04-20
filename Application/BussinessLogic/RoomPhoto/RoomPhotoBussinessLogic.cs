using Application.DTO.RoomPhoto;
using Application.Interfaces.Repository;
using AutoMapper;
using Domain.Models;
using RoomPhotoEntity = Domain.Models.RoomPhoto;

namespace Application.BussinessLogic.RoomPhoto
{
  public class RoomPhotoBussinessLogic : IRoomPhotoBussinessLogic
  {
    //private readonly IRepositoryBase<RoomPhotoEntity> _repositoryRoomPhoto;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repositoryManager;

    public RoomPhotoBussinessLogic(/*IRepositoryBase<RoomPhotoEntity> repositoryRoomPhoto,*/
                                   IMapper mapper,
                                   IRepositoryManager repositoryManager)
    {
      //_repositoryRoomPhoto = repositoryRoomPhoto;
      _mapper = mapper;
      _repositoryManager = repositoryManager;
    }

    public async Task<Guid> CreateAsync(RoomPhotoCreateWithIdDto dto)
    {
      var entity = _mapper.Map<RoomPhotoEntity>(dto);
      entity.Id = Guid.NewGuid();
      //await _repositoryRoomPhoto.CreateAsync(entity);
      await _repositoryManager.RoomPhotoRepository.CreateEntityAsync(entity);
      return entity.Id;
    }

    public async Task DeleteAsync(Guid roomPhotoId)
    {
      //var roomPhoto = await _repositoryRoomPhoto.FindOneAsync(x => x.Id == roomPhotoId);
      //_repositoryRoomPhoto.Delete(roomPhoto);
      //await _repositoryRoomPhoto.SaveAsync();

      var roomPhoto = await _repositoryManager.RoomPhotoRepository.GetOneAsync(x => x.Id == roomPhotoId);
      _repositoryManager.RoomPhotoRepository.DeleteEntity(roomPhoto);
      await _repositoryManager.SaveAsync();
    }
  }
}
