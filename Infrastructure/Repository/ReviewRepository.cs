using Application.Interfaces.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
  public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
  {
    private readonly RepositoryContext _repositoryContext;

    public ReviewRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }

    public IEnumerable<Review> GetAll(bool trackChanges) => FindAll(trackChanges).ToList();

    public async Task<IEnumerable<Review>> GetAllAsync(bool trackChanges) => await FindAll(trackChanges).ToListAsync();

    public IEnumerable<Review> GetByCondition(Expression<Func<Review, bool>> expression, bool trackChanges)
    {
      return FindByCondition(expression, trackChanges);
    }

    public Task<Review?> GetOneAsync(Expression<Func<Review, bool>> expression, bool trackChanges = false)
    {
      return FindOneAsync(expression, trackChanges);
    }

    public void CreateEntity(Review entity) => Create(entity);
    public async Task CreateEntityAsync(Review entity) => await CreateAsync(entity);
    public void UpdateEntity(Review entity) => Update(entity);
    public void DeleteEntity(Review entity) => Delete(entity);
    public async Task DeleteEntityRangeAsync(IEnumerable<Review> entities)
    {
      await DeleteRangeAsync(entities);
    }
  }
}
