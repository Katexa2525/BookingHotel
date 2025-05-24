using Application.DTO.Booking;
using Application.DTO.Hotel;
using Application.DTO.RoomFacility;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RoomFacilityEntity = Domain.Models.RoomFacility;

namespace Application.BussinessLogic.RoomFacility
{
  public class RoomFacilityBussinessLogic : IRoomFacilityBussinessLogic
  {
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repositoryManager;

    public RoomFacilityBussinessLogic(IMapper mapper, IRepositoryManager repositoryManager)
    {
      _mapper = mapper;
      _repositoryManager = repositoryManager;
    }

    public async Task<List<RoomFacilityDto>> GetAllAsync(bool trackChanges)
    {
      var listDB = _mapper.Map<List<RoomFacilityDto>>(await _repositoryManager.RoomFacilityRepository.GetAllAsync(trackChanges));
      return listDB.ToList();
    }

    public async Task<RoomFacilityDto> GetByIdAsync(Guid id, bool trackChanges)
    {
      //var roomFacility = await _repositoryRoomFacility.FindOneAsync(x => x.Id == id);
      var roomFacility = await _repositoryManager.RoomFacilityRepository.GetOneAsync(x => x.Id == id);
      return _mapper.Map<RoomFacilityDto>(roomFacility);
    }

    public async Task<Guid> CreateAsync(RoomFacilityCreateWithIdDto dto)
    {
      var entity = _mapper.Map<RoomFacilityEntity>(dto);
      entity.Id = Guid.NewGuid();

      await _repositoryManager.RoomFacilityRepository.CreateEntityAsync(entity);
      await _repositoryManager.SaveAsync();
      return entity.Id;
    }

    public async Task DeleteAsync(Guid roomFacilityId)
    {
      var roomFacility = await _repositoryManager.RoomFacilityRepository.GetOneAsync(x => x.Id == roomFacilityId);
      _repositoryManager.RoomFacilityRepository.DeleteEntity(roomFacility);
      await _repositoryManager.SaveAsync();
    }

    public async Task UpdateAsync(RoomFacilityDto dto)
    {
      //var existingroomFacility = await _repositoryRoomFacility.FindOneAsync(x => x.Id == dto.Id);
      var existingroomFacility = await _repositoryManager.RoomFacilityRepository.GetOneAsync(x => x.Id == dto.Id);
      _mapper.Map(dto, existingroomFacility);

      _repositoryManager.RoomFacilityRepository.UpdateEntity(existingroomFacility);
      await _repositoryManager.SaveAsync();
    }

    public List<RoomFacilityDto> GetByCondition(Expression<Func<RoomFacilityEntity, bool>> expression, bool trackChanges)
    {
      return _repositoryManager.RoomFacilityRepository.GetByCondition(expression, trackChanges).AsQueryable()
                                   .ProjectTo<RoomFacilityDto>(_mapper.ConfigurationProvider)
                                   .ToList();
    }
  }
}
