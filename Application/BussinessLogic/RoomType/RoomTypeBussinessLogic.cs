using Application.BussinessLogic.GeneralMethods;
using Application.DTO.Hotel;
using Application.DTO.Room;
using Application.DTO.RoomType;
using Application.Interfaces.Repository;
using AutoMapper;
using Domain.Models;
using System.Linq.Expressions;
using RoomTypeEntity = Domain.Models.RoomType;

namespace Application.BussinessLogic.RoomType
{
  public class RoomTypeBussinessLogic : IRoomTypeBussinessLogic
  {
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repositoryManager;

    public RoomTypeBussinessLogic(IMapper mapper, IRepositoryManager repositoryManager)
    {
      _mapper = mapper;
      _repositoryManager = repositoryManager;
    }

    public async Task<Guid> CreateAsync(RoomTypeCreateDto dto)
    {
      var entity = _mapper.Map<RoomTypeEntity>(dto);
      entity.Id = Guid.NewGuid();
      await _repositoryManager.RoomTypeRepository.CreateEntityAsync(entity);
      return entity.Id;
    }

    public async Task<List<RoomTypeAllDto>> GetAllAsync(bool trackChanges)
    {
      var listDB = _mapper.Map<List<RoomTypeAllDto>>(await _repositoryManager.RoomTypeRepository.GetAllAsync(trackChanges));
      return listDB.ToList();
    }

    public List<RoomTypeDto> GetByCondition(Expression<Func<Domain.Models.RoomType, bool>> expression, bool trackChanges)
    {
      var roomTypes = _repositoryManager.RoomTypeRepository.GetByCondition(expression, trackChanges).ToList();
      return _mapper.Map<List<RoomTypeDto>>(roomTypes); 
    }

    public async Task<RoomTypeDto> GetByIdAsync(Guid id, bool trackChanges)
    {
      var roomType = _repositoryManager.RoomTypeRepository.GetByCondition(x => x.Id == id, trackChanges).FirstOrDefault();
      if (roomType == null)
        return null; 
      else
        return _mapper.Map<RoomTypeDto>(roomType);
    }

    public async Task DeleteAsync(Guid roomTypeId)
    {
      var roomType = await _repositoryManager.RoomTypeRepository.GetOneAsync(x => x.Id == roomTypeId);

      _repositoryManager.RoomTypeRepository.DeleteEntity(roomType);
      await _repositoryManager.SaveAsync();
    }

    public async Task UpdateAsync(RoomTypeUpdateDto dto)
    {
      var entity = await _repositoryManager.RoomTypeRepository.GetOneAsync(x => x.Id == dto.Id);
      if (entity == null) return;

      _mapper.Map(dto, entity);

      _repositoryManager.RoomTypeRepository.UpdateEntity(entity);
      await _repositoryManager.SaveAsync();
    }
  }
}
