using Application.Interfaces.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
  public class FoodRepository : RepositoryBase<Food>, IFoodRepository
  {
    private readonly RepositoryContext _repositoryContext;

    public FoodRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }

    public IEnumerable<Food> GetAll(bool trackChanges) => FindAll(trackChanges).ToList();

    public async Task<IEnumerable<Food>> GetAllAsync(bool trackChanges) => await FindAll(trackChanges).ToListAsync();

    public IEnumerable<Food> GetByCondition(Expression<Func<Food, bool>> expression, bool trackChanges)
    {
      return FindByCondition(expression, trackChanges);
    }

    public Task<Food?> GetOneAsync(Expression<Func<Food, bool>> expression, bool trackChanges = false)
    {
      return FindOneAsync(expression, trackChanges);
    }

    public void CreateEntity(Food entity) => Create(entity);
    public async Task CreateEntityAsync(Food entity) => await CreateAsync(entity);
    public void UpdateEntity(Food entity) => Update(entity);
    public void DeleteEntity(Food entity) => Delete(entity);
    public async Task DeleteEntityRangeAsync(IEnumerable<Food> entities)
    {
      await DeleteRangeAsync(entities);
    }
  }
}
