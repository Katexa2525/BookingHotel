using Application.DTO.Location;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using LocationEntity = Domain.Models.Location;

namespace Application.BussinessLogic.Location
{
  public class LocationBussinessLogic : ILocationBussinessLogic
  {
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repositoryManager;

    public LocationBussinessLogic(IMapper mapper, IRepositoryManager repositoryManager)
    {
      _mapper = mapper;
      _repositoryManager = repositoryManager;
    }

    public async Task<List<LocationDto>> GetAllAsync(bool trackChanges)
    {
      return await _repositoryManager.LocationRepository.GetAll(trackChanges).AsQueryable()
                                  .ProjectTo<LocationDto>(_mapper.ConfigurationProvider)
                                  .ToListAsync();
    }

    public async Task<LocationDto> GetByIdAsync(Guid id, bool trackChanges)
    {
      //var food = await _repositoryLocation.FindOneAsync(x => x.Id == id);
      var food = await _repositoryManager.LocationRepository.GetOneAsync(x => x.Id == id, trackChanges);
      return _mapper.Map<LocationDto>(food);
    }

    public async Task<Guid> CreateAsync(LocationCreateWithIdDto dto)
    {
      var entity = _mapper.Map<LocationEntity>(dto);
      entity.Id = Guid.NewGuid();
      //await _repositoryLocation.CreateAsync(entity);
      await _repositoryManager.LocationRepository.CreateEntityAsync(entity);
      return entity.Id;
    }

    public async Task DeleteAsync(Guid locationId)
    {
      var location = await _repositoryManager.LocationRepository.GetOneAsync(x => x.Id == locationId);
      _repositoryManager.LocationRepository.DeleteEntity(location);
      await _repositoryManager.SaveAsync();
    }

    public async Task UpdateAsync(LocationDto dto)
    {
      //var existingLocation = await _repositoryLocation.FindOneAsync(x => x.Id == dto.Id);
      var existingLocation = await _repositoryManager.LocationRepository.GetOneAsync(x => x.Id == dto.Id);
      _mapper.Map(dto, existingLocation);

      _repositoryManager.LocationRepository.UpdateEntity(existingLocation);
      await _repositoryManager.SaveAsync();
    }

    public List<LocationDto> GetByCondition(Expression<Func<LocationEntity, bool>> expression, bool trackChanges)
    {
      return _repositoryManager.LocationRepository.GetByCondition(expression, trackChanges).AsQueryable()
                                   .ProjectTo<LocationDto>(_mapper.ConfigurationProvider)
                                   .ToList();
    }
  }
}
