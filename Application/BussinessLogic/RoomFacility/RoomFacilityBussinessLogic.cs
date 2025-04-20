using Application.DTO.Food;
using Application.DTO.RoomFacility;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using RoomFacilityEntity = Domain.Models.RoomFacility;

namespace Application.BussinessLogic.RoomFacility
{
  public class RoomFacilityBussinessLogic : IRoomFacilityBussinessLogic
  {
    //private readonly IRepositoryBase<RoomFacilityEntity> _repositoryRoomFacility;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repositoryManager;

    public RoomFacilityBussinessLogic(/*IRepositoryBase<RoomFacilityEntity> repositoryRoomFacility,*/ IMapper mapper, IRepositoryManager repositoryManager)
    {
      //_repositoryRoomFacility = repositoryRoomFacility;
      _mapper = mapper;
      _repositoryManager = repositoryManager;
    }

    public async Task<List<RoomFacilityDto>> GetAllAsync()
    {
      //return await _repositoryRoomFacility.FindAll()
      //                             .ProjectTo<RoomFacilityDto>(_mapper.ConfigurationProvider)
      //                             .ToListAsync();

      return await _repositoryManager.RoomFacilityRepository.GetAll(trackChanges: true).AsQueryable()
                                  .ProjectTo<RoomFacilityDto>(_mapper.ConfigurationProvider)
                                  .ToListAsync();
    }

    public async Task<RoomFacilityDto> GetByIdAsync(Guid id)
    {
      //var roomFacility = await _repositoryRoomFacility.FindOneAsync(x => x.Id == id);
      var roomFacility = await _repositoryManager.RoomFacilityRepository.GetOneAsync(x => x.Id == id);
      return _mapper.Map<RoomFacilityDto>(roomFacility);
    }

    public async Task<Guid> CreateAsync(RoomFacilityCreateWithIdDto dto)
    {
      var entity = _mapper.Map<RoomFacilityEntity>(dto);
      entity.Id = Guid.NewGuid();
      //await _repositoryRoomFacility.CreateAsync(entity);
      await _repositoryManager.RoomFacilityRepository.CreateEntityAsync(entity);
      return entity.Id;
    }

    public async Task DeleteAsync(Guid roomFacilityId)
    {
      //var roomFacility = await _repositoryRoomFacility.FindOneAsync(x => x.Id == roomFacilityId);
      //_repositoryRoomFacility.Delete(roomFacility);
      //await _repositoryRoomFacility.SaveAsync();

      var roomFacility = await _repositoryManager.RoomFacilityRepository.GetOneAsync(x => x.Id == roomFacilityId);
      _repositoryManager.RoomFacilityRepository.DeleteEntity(roomFacility);
      await _repositoryManager.SaveAsync();
    }

    public async Task UpdateAsync(RoomFacilityDto dto)
    {
      //var existingroomFacility = await _repositoryRoomFacility.FindOneAsync(x => x.Id == dto.Id);
      var existingroomFacility = await _repositoryManager.RoomFacilityRepository.GetOneAsync(x => x.Id == dto.Id);
      _mapper.Map(dto, existingroomFacility);

      //_repositoryRoomFacility.Update(existingroomFacility);
      //await _repositoryRoomFacility.SaveAsync();

      _repositoryManager.RoomFacilityRepository.UpdateEntity(existingroomFacility);
      await _repositoryManager.SaveAsync();
    }
  }
}
