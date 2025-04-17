using Application.DTO.Location;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using LocationEntity = Domain.Models.Location;

namespace Application.BussinessLogic.Location
{
  public class LocationBussinessLogic : ILocationBussinessLogic
  {
    private readonly IRepositoryBase<LocationEntity> _repositoryLocation;
    private readonly IMapper _mapper;
    public LocationBussinessLogic(IRepositoryBase<LocationEntity> repositoryLocation,
      IMapper mapper)
    {
      _repositoryLocation = repositoryLocation;
      _mapper = mapper;
    }

    public async Task<List<LocationDto>> GetAllAsync()
    {
      return await _repositoryLocation.FindAll()
                                   .ProjectTo<LocationDto>(_mapper.ConfigurationProvider)
                                   .ToListAsync();
    }

    public async Task<LocationDto> GetByIdAsync(Guid id)
    {
      var food = await _repositoryLocation.FindOneAsync(x => x.Id == id);
      return _mapper.Map<LocationDto>(food);
    }

    public async Task<Guid> CreateAsync(LocationCreateWithIdDto dto)
    {
      var entity = _mapper.Map<LocationEntity>(dto);
      entity.Id = Guid.NewGuid();
      await _repositoryLocation.CreateAsync(entity);
      return entity.Id;
    }

    public async Task DeleteAsync(Guid locationId)
    {
      var location = await _repositoryLocation.FindOneAsync(x => x.Id == locationId);
      _repositoryLocation.Delete(location);
      await _repositoryLocation.SaveAsync();
    }

    public async Task UpdateAsync(LocationDto dto)
    {
      var existingLocation = await _repositoryLocation.FindOneAsync(x => x.Id == dto.Id);
      _mapper.Map(dto, existingLocation);
      _repositoryLocation.Update(existingLocation);
      await _repositoryLocation.SaveAsync();
    }
  }
}
