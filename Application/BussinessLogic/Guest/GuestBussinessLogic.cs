using Application.DTO.Booking;
using Application.DTO.Guest;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq.Expressions;
using GuestEntity = Domain.Models.Guest;

namespace Application.BussinessLogic.Guest
{
  public class GuestBussinessLogic : IGuestBussinessLogic
  {
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public GuestBussinessLogic(IRepositoryManager repositoryManager, IMapper mapper)
    {
      _repositoryManager = repositoryManager;
      _mapper = mapper;
    }

    public async Task<List<GuestAllDto>> GetAllAsync(bool trackChanges)
    {
      var listDB = _mapper.Map<List<GuestAllDto>>(await _repositoryManager.GuestRepository.GetAllAsync(trackChanges));
      return listDB.ToList();
    }

    public async Task<GuestDto> GetByIdAsync(Guid id, bool trackChanges)
    {
      var guest = _repositoryManager.GuestRepository.GetByCondition(x => x.Id == id, trackChanges).FirstOrDefault();
      if (guest == null)
        return null;
      else
        return _mapper.Map<GuestDto>(guest);
    }

    public async Task<Guid> CreateAsync(GuestCreateDto dto) 
    {
      var entity = _mapper.Map<GuestEntity>(dto);
      entity.Id = Guid.NewGuid();

      await _repositoryManager.GuestRepository.CreateEntityAsync(entity);
      await _repositoryManager.SaveAsync();
      return entity.Id;
    }

    public async Task DeleteAsync(Guid id)
    {
      var guest = await _repositoryManager.GuestRepository.GetOneAsync(x => x.Id == id, trackChanges: true);

      if (guest is not null)
      {
        _repositoryManager.GuestRepository.DeleteEntity(guest);
        await _repositoryManager.SaveAsync();
      }
    }

    public async Task UpdateAsync(GuestUpdateDto dto)
    {
      var entity = await _repositoryManager.GuestRepository.GetOneAsync(x => x.Id == dto.Id, trackChanges: true);
      if (entity == null) return;

      _mapper.Map(dto, entity);

      _repositoryManager.GuestRepository.UpdateEntity(entity);
      await _repositoryManager.SaveAsync();
    }

    public List<GuestDto> GetByCondition(Expression<Func<GuestEntity, bool>> expression, bool trackChanges)
    {
      return _repositoryManager.GuestRepository.GetByCondition(expression, trackChanges).AsQueryable()
                                   .ProjectTo<GuestDto>(_mapper.ConfigurationProvider)
                                   .ToList();
    }
  }
}
