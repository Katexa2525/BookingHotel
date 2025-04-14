using Application.DTO.Price;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PriceEntity = Domain.Models.Price;

namespace Application.BussinessLogic.Price
{
  public class PriceBussinessLogic : IPriceBussinessLogic
  {
    private readonly IRepositoryBase<PriceEntity> _repositoryPrice;
    private readonly IMapper _mapper;
    public PriceBussinessLogic(IRepositoryBase<PriceEntity> repositoryPrice)
    {
      _repositoryPrice = repositoryPrice;
    }

    public async Task<List<PriceDto>> GetAllAsync()
    {
      return await _repositoryPrice.FindAll()
                                   .ProjectTo<PriceDto>(_mapper.ConfigurationProvider)
                                   .ToListAsync();
    }

    public async Task<PriceDto> GetByIdAsync(Guid id)
    {
      var price = await _repositoryPrice.FindOneAsync(x => x.Id == id);
      return _mapper.Map<PriceDto>(price);
    }

    public async Task<Guid> CreateAsync(PriceCreateWithIdDto dto)
    {
      var entity = _mapper.Map<PriceEntity>(dto);
      entity.Id = Guid.NewGuid();
      await _repositoryPrice.CreateAsync(entity);
      return entity.Id;
    }

    public async Task DeleteAsync(Guid priceId)
    {
      var price = await _repositoryPrice.FindOneAsync(x => x.Id == priceId);
      _repositoryPrice.Delete(price);
      await _repositoryPrice.SaveAsync();
    }

    public async Task UpdateAsync(PriceDto dto)
    {
      var existingPrice = await _repositoryPrice.FindOneAsync(x => x.Id == dto.Id);
      _mapper.Map(dto, existingPrice);
      _repositoryPrice.Update(existingPrice);
      await _repositoryPrice.SaveAsync();
    }
  }
}
