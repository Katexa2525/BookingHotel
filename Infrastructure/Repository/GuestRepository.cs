using Application.Interfaces.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
  public class GuestRepository : RepositoryBase<Guest>, IGuestRepository
  {
    private readonly RepositoryContext _repositoryContext;

    public GuestRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }

    public IEnumerable<Guest> GetAll(bool trackChanges)
    {
      return FindAll(trackChanges).Include(h => h.Booking).ToList();
    }

    public async Task<IEnumerable<Guest>> GetAllAsync(bool trackChanges)
    {
      return await FindAll(trackChanges).Include(h => h.Booking).ToListAsync();
    }

    public IEnumerable<Guest> GetByCondition(Expression<Func<Guest, bool>> expression, bool trackChanges)
    {
      return FindByCondition(expression, trackChanges).Include(h => h.Booking);
    }

    public Task<Guest?> GetOneAsync(Expression<Func<Guest, bool>> expression, bool trackChanges = false)
    {
      return FindOneAsync(expression, trackChanges);
    }

    public void CreateEntity(Guest entity) => Create(entity);
    public async Task CreateEntityAsync(Guest entity) => await CreateAsync(entity);
    public void UpdateEntity(Guest entity) => Update(entity);
    public void DeleteEntity(Guest entity) => Delete(entity);
    public async Task DeleteEntityRangeAsync(IEnumerable<Guest> entities)
    {
      await DeleteRangeAsync(entities);
    }
  }
}
