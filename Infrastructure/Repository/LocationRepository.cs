using Application.Interfaces.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
  public class LocationRepository : RepositoryBase<Location>, ILocationRepository
  {
    private readonly RepositoryContext _repositoryContext;

    public LocationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }

    public IEnumerable<Location> GetAll(bool trackChanges) => FindAll(trackChanges).ToList();

    public async Task<IEnumerable<Location>> GetAllAsync(bool trackChanges) => await FindAll(trackChanges).ToListAsync();

    public IEnumerable<Location> GetByCondition(Expression<Func<Location, bool>> expression, bool trackChanges)
    {
      return FindByCondition(expression, trackChanges);
    }

    public Task<Location?> GetOneAsync(Expression<Func<Location, bool>> expression, bool trackChanges = false)
    {
      return FindOneAsync(expression, trackChanges);
    }

    public void CreateEntity(Location entity) => Create(entity);
    public async Task CreateEntityAsync(Location entity) => await CreateAsync(entity);
    public void UpdateEntity(Location entity) => Update(entity);
    public void DeleteEntity(Location entity) => Delete(entity);
    public async Task DeleteEntityRangeAsync(IEnumerable<Location> entities)
    {
      await DeleteRangeAsync(entities);
    }
  }
}
