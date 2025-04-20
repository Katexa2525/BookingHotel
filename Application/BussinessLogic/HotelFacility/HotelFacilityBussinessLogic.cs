using Application.DTO.HotelFacility;
using Application.DTO.RoomFacility;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using HotelFacilityEntity = Domain.Models.HotelFacility;

namespace Application.BussinessLogic.HotelFacility
{
  public class HotelFacilityBussinessLogic : IHotelFacilityBussinessLogic
  {
    //private readonly IRepositoryBase<HotelFacilityEntity> _repositoryHotelFacility;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repositoryManager;

    public HotelFacilityBussinessLogic(/*IRepositoryBase<HotelFacilityEntity> repositoryHotelFacility, */ IMapper mapper, IRepositoryManager repositoryManager)
    {
      //_repositoryHotelFacility = repositoryHotelFacility;
      _mapper = mapper;
      _repositoryManager = repositoryManager;
    }

    public async Task<List<HotelFacilityDto>> GetAllAsync()
    {
      //return await _repositoryHotelFacility.FindAll()
      //                             .ProjectTo<HotelFacilityDto>(_mapper.ConfigurationProvider)
      //                             .ToListAsync();

      return await _repositoryManager.HotelFacilityRepository.GetAll(trackChanges: true).AsQueryable()
                                  .ProjectTo<HotelFacilityDto>(_mapper.ConfigurationProvider)
                                  .ToListAsync();
    }

    public async Task<HotelFacilityDto> GetByIdAsync(Guid id)
    {
      //var hotelFacility = await _repositoryHotelFacility.FindOneAsync(x => x.Id == id);
      var hotelFacility = await _repositoryManager.HotelFacilityRepository.GetOneAsync(x => x.Id == id);
      return _mapper.Map<HotelFacilityDto>(hotelFacility);
    }

    public async Task<Guid> CreateAsync(HotelFacilityCreateWithIdDto dto)
    {
      var entity = _mapper.Map<HotelFacilityEntity>(dto);
      entity.Id = Guid.NewGuid();
      //await _repositoryHotelFacility.CreateAsync(entity);
      await _repositoryManager.HotelFacilityRepository.CreateEntityAsync(entity);
      return entity.Id;
    }

    public async Task DeleteAsync(Guid hotelFacilityId)
    {
      //var hotelFacility = await _repositoryHotelFacility.FindOneAsync(x => x.Id == hotelFacilityId);
      //_repositoryHotelFacility.Delete(hotelFacility);
      //await _repositoryHotelFacility.SaveAsync();

      var hotelFacility = await _repositoryManager.HotelFacilityRepository.GetOneAsync(x => x.Id == hotelFacilityId);
      _repositoryManager.HotelFacilityRepository.DeleteEntity(hotelFacility);
      await _repositoryManager.SaveAsync();
    }

    public async Task UpdateAsync(HotelFacilityDto dto)
    {
      //var existingHotelFacility = await _repositoryHotelFacility.FindOneAsync(x => x.Id == dto.Id);
      var existingHotelFacility = await _repositoryManager.HotelFacilityRepository.GetOneAsync(x => x.Id == dto.Id);
      _mapper.Map(dto, existingHotelFacility);

      //_repositoryHotelFacility.Update(existingHotelFacility);
      //await _repositoryHotelFacility.SaveAsync();

      _repositoryManager.HotelFacilityRepository.UpdateEntity(existingHotelFacility);
      await _repositoryManager.SaveAsync();
    }
  }
}
