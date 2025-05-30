using Application.DTO.HotelPhoto;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq.Expressions;
using HotelPhotoEntity = Domain.Models.HotelPhoto;

namespace Application.BussinessLogic.HotelPhoto
{
  public class HotelPhotoBussinessLogic : IHotelPhotoBussinessLogic
  {
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repositoryManager;

    public HotelPhotoBussinessLogic(IMapper mapper, IRepositoryManager repositoryManager)
    {
      _mapper = mapper;
      _repositoryManager = repositoryManager;
    }

    public async Task<Guid> CreateAsync(HotelPhotoCreateWithIdDto dto)
    {
      var entity = _mapper.Map<HotelPhotoEntity>(dto);
      entity.Id = Guid.NewGuid();

      await _repositoryManager.HotelPhotoRepository.CreateEntityAsync(entity);
      await _repositoryManager.SaveAsync();
      return entity.Id;
    }

    public async Task DeleteAsync(Guid hotelPhotoId)
    {

      var hotelPhoto = await _repositoryManager.HotelPhotoRepository.GetOneAsync(x => x.Id == hotelPhotoId);
      _repositoryManager.HotelPhotoRepository.DeleteEntity(hotelPhoto);
      await _repositoryManager.SaveAsync();
    }

    public List<HotelPhotoDto> GetByCondition(Expression<Func<HotelPhotoEntity, bool>> expression, bool trackChanges)
    {
      return _repositoryManager.HotelPhotoRepository.GetByCondition(expression, trackChanges).AsQueryable()
                                  .ProjectTo<HotelPhotoDto>(_mapper.ConfigurationProvider)
                                  .ToList();
    }

    public async Task<HotelPhotoDto> GetByIdAsync(Guid id, bool trackChanges)
    {
      var photo = await _repositoryManager.HotelPhotoRepository.GetOneAsync(x => x.Id == id, trackChanges);
      return _mapper.Map<HotelPhotoDto>(photo);
    }

    public async Task UpdateAsync(HotelPhotoDto dto)
    {
      var existingPhoto = await _repositoryManager.HotelPhotoRepository.GetOneAsync(x => x.Id == dto.Id);
      _mapper.Map(dto, existingPhoto);

      _repositoryManager.HotelPhotoRepository.UpdateEntity(existingPhoto);
      await _repositoryManager.SaveAsync();
    }

  }
}
