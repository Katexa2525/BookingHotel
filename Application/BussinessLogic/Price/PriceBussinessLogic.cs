using Application.DTO.Price;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using PriceEntity = Domain.Models.Price;

namespace Application.BussinessLogic.Price
{
  public class PriceBussinessLogic : IPriceBussinessLogic
  {
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repositoryManager;

    public PriceBussinessLogic(IMapper mapper, IRepositoryManager repositoryManager)
    {
      _mapper = mapper;
      _repositoryManager = repositoryManager;
    }

    public async Task<List<PriceDto>> GetAllAsync(bool trackChanges)
    {
      return await _repositoryManager.PriceRepository.GetAll(trackChanges).AsQueryable()
                                  .ProjectTo<PriceDto>(_mapper.ConfigurationProvider)
                                  .ToListAsync();
    }

    public async Task<PriceDto> GetByIdAsync(Guid id, bool trackChanges)
    {
      var price = await _repositoryManager.PriceRepository.GetOneAsync(x => x.Id == id, trackChanges);
      return _mapper.Map<PriceDto>(price);
    }

    public async Task<Guid> CreateAsync(PriceCreateWithIdDto dto)
    {
      var entity = _mapper.Map<PriceEntity>(dto);
      entity.Id = Guid.NewGuid();
      await _repositoryManager.PriceRepository.CreateEntityAsync(entity);
      await _repositoryManager.SaveAsync();
      return entity.Id;
    }

    public async Task DeleteAsync(Guid priceId)
    {
      var price = await _repositoryManager.PriceRepository.GetOneAsync(x => x.Id == priceId);
      _repositoryManager.PriceRepository.DeleteEntity(price);
      await _repositoryManager.SaveAsync();
    }

    public async Task UpdateAsync(PriceDto dto)
    {
      var existingPrice = await _repositoryManager.PriceRepository.GetOneAsync(x => x.Id == dto.Id);
      _mapper.Map(dto, existingPrice);

      _repositoryManager.PriceRepository.UpdateEntity(existingPrice);
      await _repositoryManager.SaveAsync();
    }

    public List<PriceDto> GetByCondition(Expression<Func<PriceEntity, bool>> expression, bool trackChanges)
    {
      return _repositoryManager.PriceRepository.GetByCondition(expression, trackChanges)
                                               .OrderBy(p=>p.DateStart).OrderBy(r=>r.DateEnd)
                                               .AsQueryable()
                                               .ProjectTo<PriceDto>(_mapper.ConfigurationProvider)
                                               .ToList();
    }
  }
}
