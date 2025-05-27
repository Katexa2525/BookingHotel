using Application.DTO.Review;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ReviewEntity = Domain.Models.Review;

namespace Application.BussinessLogic.Review
{
  public class ReviewBussinessLogic : IReviewBussinessLogic
  {
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repositoryManager;

    public ReviewBussinessLogic(IMapper mapper, IRepositoryManager repositoryManager)
    {
      _mapper = mapper;
      _repositoryManager = repositoryManager;
    }

    public async Task<List<ReviewDto>> GetAllAsync(bool trackChanges)
    {
      return await _repositoryManager.PriceRepository.GetAll(trackChanges).AsQueryable()
                                  .ProjectTo<ReviewDto>(_mapper.ConfigurationProvider)
                                  .ToListAsync();
    }

    public async Task<ReviewDto> GetByIdAsync(Guid id, bool trackChanges)
    {
      var price = await _repositoryManager.ReviewRepository.GetOneAsync(x => x.Id == id, trackChanges);
      return _mapper.Map<ReviewDto>(price);
    }

    public async Task<Guid> CreateAsync(ReviewCreateWithIdDto dto)
    {
      var entity = _mapper.Map<ReviewEntity>(dto);
      entity.Id = Guid.NewGuid();
      await _repositoryManager.ReviewRepository.CreateEntityAsync(entity);
      await _repositoryManager.SaveAsync();
      return entity.Id;
    }

    public async Task DeleteAsync(Guid reviewId)
    {
      var review = await _repositoryManager.ReviewRepository.GetOneAsync(x => x.Id == reviewId);
      _repositoryManager.ReviewRepository.DeleteEntity(review);
      await _repositoryManager.SaveAsync();
    }

    public async Task UpdateAsync(ReviewDto dto)
    {
      var existingPrice = await _repositoryManager.ReviewRepository.GetOneAsync(x => x.Id == dto.Id);
      _mapper.Map(dto, existingPrice);

      _repositoryManager.ReviewRepository.UpdateEntity(existingPrice);
      await _repositoryManager.SaveAsync();
    }

    public List<ReviewDto> GetByCondition(Expression<Func<ReviewEntity, bool>> expression, bool trackChanges)
    {
      return _repositoryManager.ReviewRepository.GetByCondition(expression, trackChanges).AsQueryable()
                                  .ProjectTo<ReviewDto>(_mapper.ConfigurationProvider)
                                  .ToList();
    }

  }
}
