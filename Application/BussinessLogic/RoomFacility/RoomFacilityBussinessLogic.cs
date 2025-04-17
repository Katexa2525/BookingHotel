using Application.DTO.RoomFacility;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RoomFacilityEntity = Domain.Models.RoomFacility;

namespace Application.BussinessLogic.RoomFacility
{
  public class RoomFacilityBussinessLogic : IRoomFacilityBussinessLogic
  {
    private readonly IRepositoryBase<RoomFacilityEntity> _repositoryRoomFacility;
    private readonly IMapper _mapper;
    public RoomFacilityBussinessLogic(IRepositoryBase<RoomFacilityEntity> repositoryRoomFacility, IMapper mapper)
    {
      _repositoryRoomFacility = repositoryRoomFacility;
      _mapper = mapper;
    }

    public async Task<List<RoomFacilityDto>> GetAllAsync()
    {
      return await _repositoryRoomFacility.FindAll()
                                   .ProjectTo<RoomFacilityDto>(_mapper.ConfigurationProvider)
                                   .ToListAsync();
    }

    public async Task<RoomFacilityDto> GetByIdAsync(Guid id)
    {
      var roomFacility = await _repositoryRoomFacility.FindOneAsync(x => x.Id == id);
      return _mapper.Map<RoomFacilityDto>(roomFacility);
    }

    public async Task<Guid> CreateAsync(RoomFacilityCreateWithIdDto dto)
    {
      var entity = _mapper.Map<RoomFacilityEntity>(dto);
      entity.Id = Guid.NewGuid();
      await _repositoryRoomFacility.CreateAsync(entity);
      return entity.Id;
    }

    public async Task DeleteAsync(Guid roomFacilityId)
    {
      var roomFacility = await _repositoryRoomFacility.FindOneAsync(x => x.Id == roomFacilityId);
      _repositoryRoomFacility.Delete(roomFacility);
      await _repositoryRoomFacility.SaveAsync();
    }

    public async Task UpdateAsync(RoomFacilityDto dto)
    {
      var existingroomFacility = await _repositoryRoomFacility.FindOneAsync(x => x.Id == dto.Id);
      _mapper.Map(dto, existingroomFacility);
      _repositoryRoomFacility.Update(existingroomFacility);
      await _repositoryRoomFacility.SaveAsync();
    }
  }
}
