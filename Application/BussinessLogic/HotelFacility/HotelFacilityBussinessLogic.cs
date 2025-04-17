using Application.DTO.HotelFacility;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using HotelFacilityEntity = Domain.Models.HotelFacility;

namespace Application.BussinessLogic.HotelFacility
{
  public class HotelFacilityBussinessLogic : IHotelFacilityBussinessLogic
  {
    private readonly IRepositoryBase<HotelFacilityEntity> _repositoryHotelFacility;
    private readonly IMapper _mapper;
    public HotelFacilityBussinessLogic(IRepositoryBase<HotelFacilityEntity> repositoryHotelFacility, IMapper mapper)
    {
      _repositoryHotelFacility = repositoryHotelFacility;
      _mapper = mapper;
    }

    public async Task<List<HotelFacilityDto>> GetAllAsync()
    {
      return await _repositoryHotelFacility.FindAll()
                                   .ProjectTo<HotelFacilityDto>(_mapper.ConfigurationProvider)
                                   .ToListAsync();
    }

    public async Task<HotelFacilityDto> GetByIdAsync(Guid id)
    {
      var hotelFacility = await _repositoryHotelFacility.FindOneAsync(x => x.Id == id);
      return _mapper.Map<HotelFacilityDto>(hotelFacility);
    }

    public async Task<Guid> CreateAsync(HotelFacilityCreateWithIdDto dto)
    {
      var entity = _mapper.Map<HotelFacilityEntity>(dto);
      entity.Id = Guid.NewGuid();
      await _repositoryHotelFacility.CreateAsync(entity);
      return entity.Id;
    }

    public async Task DeleteAsync(Guid hotelFacilityId)
    {
      var hotelFacility = await _repositoryHotelFacility.FindOneAsync(x => x.Id == hotelFacilityId);
      _repositoryHotelFacility.Delete(hotelFacility);
      await _repositoryHotelFacility.SaveAsync();
    }

    public async Task UpdateAsync(HotelFacilityDto dto)
    {
      var existingHotelFacility = await _repositoryHotelFacility.FindOneAsync(x => x.Id == dto.Id);
      _mapper.Map(dto, existingHotelFacility);
      _repositoryHotelFacility.Update(existingHotelFacility);
      await _repositoryHotelFacility.SaveAsync();
    }
  }
}
