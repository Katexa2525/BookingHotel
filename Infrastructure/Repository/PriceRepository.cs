using Application.Interfaces.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
  public class PriceRepository : RepositoryBase<Price>, IPriceRepository
  {
    private readonly RepositoryContext _repositoryContext;

    public PriceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }

    public IEnumerable<Price> GetAll(bool trackChanges) => FindAll(trackChanges).ToList();

    public async Task<IEnumerable<Price>> GetAllAsync(bool trackChanges) => await FindAll(trackChanges).ToListAsync();

    public IEnumerable<Price> GetByCondition(Expression<Func<Price, bool>> expression, bool trackChanges)
    {
      return FindByCondition(expression, trackChanges);
    }

    public Task<Price?> GetOneAsync(Expression<Func<Price, bool>> expression, bool trackChanges = false)
    {
      return FindOneAsync(expression, trackChanges);
    }

    public void CreateEntity(Price entity) => Create(entity);
    public async Task CreateEntityAsync(Price entity) => await CreateAsync(entity);
    public void UpdateEntity(Price entity) => Update(entity);
    public void DeleteEntity(Price entity) => Delete(entity);
  }
}
