using Application.DTO.HotelFacility;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using HotelFacilityEntity = Domain.Models.HotelFacility;

namespace Application.BussinessLogic.HotelFacility
{
  public class HotelFacilityBussinessLogic : IHotelFacilityBussinessLogic
  {
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repositoryManager;

    public HotelFacilityBussinessLogic(IMapper mapper, IRepositoryManager repositoryManager)
    {
      _mapper = mapper;
      _repositoryManager = repositoryManager;
    }

    public async Task<List<HotelFacilityDto>> GetAllAsync(bool trackChanges)
    {
      return await _repositoryManager.HotelFacilityRepository.GetAll(trackChanges).AsQueryable()
                                  .ProjectTo<HotelFacilityDto>(_mapper.ConfigurationProvider)
                                  .ToListAsync();
    }

    public async Task<HotelFacilityDto> GetByIdAsync(Guid id, bool trackChanges)
    {
      //var hotelFacility = await _repositoryHotelFacility.FindOneAsync(x => x.Id == id);
      var hotelFacility = await _repositoryManager.HotelFacilityRepository.GetOneAsync(x => x.Id == id, trackChanges);
      return _mapper.Map<HotelFacilityDto>(hotelFacility);
    }

    public async Task<Guid> CreateAsync(HotelFacilityCreateWithIdDto dto)
    {
      var entity = _mapper.Map<HotelFacilityEntity>(dto);
      entity.Id = Guid.NewGuid();

      await _repositoryManager.HotelFacilityRepository.CreateEntityAsync(entity);
      await _repositoryManager.SaveAsync();
      return entity.Id;
    }

    public async Task DeleteAsync(Guid hotelFacilityId)
    {
      var hotelFacility = await _repositoryManager.HotelFacilityRepository.GetOneAsync(x => x.Id == hotelFacilityId);
      _repositoryManager.HotelFacilityRepository.DeleteEntity(hotelFacility);
      await _repositoryManager.SaveAsync();
    }

    public async Task UpdateAsync(HotelFacilityDto dto)
    {
      //var existingHotelFacility = await _repositoryHotelFacility.FindOneAsync(x => x.Id == dto.Id);
      var existingHotelFacility = await _repositoryManager.HotelFacilityRepository.GetOneAsync(x => x.Id == dto.Id);
      _mapper.Map(dto, existingHotelFacility);

      _repositoryManager.HotelFacilityRepository.UpdateEntity(existingHotelFacility);
      await _repositoryManager.SaveAsync();
    }

    public List<HotelFacilityDto> GetByCondition(Expression<Func<HotelFacilityEntity, bool>> expression, bool trackChanges)
    {
      return _repositoryManager.HotelFacilityRepository.GetByCondition(expression, trackChanges).AsQueryable()
                                   .ProjectTo<HotelFacilityDto>(_mapper.ConfigurationProvider)
                                   .ToList();
    }
  }
}
