using Application.DTO.RoomPhoto;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq.Expressions;
using RoomPhotoEntity = Domain.Models.RoomPhoto;

namespace Application.BussinessLogic.RoomPhoto
{
  public class RoomPhotoBussinessLogic : IRoomPhotoBussinessLogic
  {
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repositoryManager;

    public RoomPhotoBussinessLogic(IMapper mapper, IRepositoryManager repositoryManager)
    {
      _mapper = mapper;
      _repositoryManager = repositoryManager;
    }

    public async Task<Guid> CreateAsync(RoomPhotoCreateWithIdDto dto)
    {
      var entity = _mapper.Map<RoomPhotoEntity>(dto);
      entity.Id = Guid.NewGuid();

      await _repositoryManager.RoomPhotoRepository.CreateEntityAsync(entity);
      await _repositoryManager.SaveAsync();
      return entity.Id;
    }

    public async Task DeleteAsync(Guid roomPhotoId)
    {
      var roomPhoto = await _repositoryManager.RoomPhotoRepository.GetOneAsync(x => x.Id == roomPhotoId);
      _repositoryManager.RoomPhotoRepository.DeleteEntity(roomPhoto);
      await _repositoryManager.SaveAsync();
    }

    public List<RoomPhotoDto> GetByCondition(Expression<Func<RoomPhotoEntity, bool>> expression, bool trackChanges)
    {
      return _repositoryManager.RoomPhotoRepository.GetByCondition(expression, trackChanges).AsQueryable()
                                  .ProjectTo<RoomPhotoDto>(_mapper.ConfigurationProvider)
                                  .ToList();
    }

    public async Task<RoomPhotoDto> GetByIdAsync(Guid id, bool trackChanges)
    {
      var photo = await _repositoryManager.RoomPhotoRepository.GetOneAsync(x => x.Id == id, trackChanges);
      return _mapper.Map<RoomPhotoDto>(photo);
    }
  }
}
