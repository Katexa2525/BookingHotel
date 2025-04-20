using Application.DTO.Location;
using Application.DTO.Price;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using PriceEntity = Domain.Models.Price;

namespace Application.BussinessLogic.Price
{
  public class PriceBussinessLogic : IPriceBussinessLogic
  {
    //private readonly IRepositoryBase<PriceEntity> _repositoryPrice;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repositoryManager;

    public PriceBussinessLogic(/*IRepositoryBase<PriceEntity> repositoryPrice,*/ IMapper mapper, IRepositoryManager repositoryManager)
    {
      //_repositoryPrice = repositoryPrice;
      _mapper = mapper;
      _repositoryManager = repositoryManager;
    }

    public async Task<List<PriceDto>> GetAllAsync()
    {
      //return await _repositoryPrice.FindAll()
      //                             .ProjectTo<PriceDto>(_mapper.ConfigurationProvider)
      //                             .ToListAsync();

      return await _repositoryManager.PriceRepository.GetAll(trackChanges: true).AsQueryable()
                                  .ProjectTo<PriceDto>(_mapper.ConfigurationProvider)
                                  .ToListAsync();
    }

    public async Task<PriceDto> GetByIdAsync(Guid id)
    {
      //var price = await _repositoryPrice.FindOneAsync(x => x.Id == id);
      var price = await _repositoryManager.PriceRepository.GetOneAsync(x => x.Id == id);
      return _mapper.Map<PriceDto>(price);
    }

    public async Task<Guid> CreateAsync(PriceCreateWithIdDto dto)
    {
      var entity = _mapper.Map<PriceEntity>(dto);
      entity.Id = Guid.NewGuid();
      //await _repositoryPrice.CreateAsync(entity);
      await _repositoryManager.PriceRepository.CreateEntityAsync(entity);
      return entity.Id;
    }

    public async Task DeleteAsync(Guid priceId)
    {
      //var price = await _repositoryPrice.FindOneAsync(x => x.Id == priceId);
      //_repositoryPrice.Delete(price);
      //await _repositoryPrice.SaveAsync();

      var price = await _repositoryManager.PriceRepository.GetOneAsync(x => x.Id == priceId);
      _repositoryManager.PriceRepository.DeleteEntity(price);
      await _repositoryManager.SaveAsync();
    }

    public async Task UpdateAsync(PriceDto dto)
    {
      //var existingPrice = await _repositoryPrice.FindOneAsync(x => x.Id == dto.Id);
      var existingPrice = await _repositoryManager.PriceRepository.GetOneAsync(x => x.Id == dto.Id);
      _mapper.Map(dto, existingPrice);

      //_repositoryPrice.Update(existingPrice);
      //await _repositoryPrice.SaveAsync();

      _repositoryManager.PriceRepository.UpdateEntity(existingPrice);
      await _repositoryManager.SaveAsync();
    }
  }
}
