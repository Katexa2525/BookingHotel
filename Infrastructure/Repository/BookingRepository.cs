using Application.Interfaces.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
  public class BookingRepository : RepositoryBase<Booking>, IBookingRepository
  {
    private readonly RepositoryContext _repositoryContext;

    public BookingRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }

    public IEnumerable<Booking> GetAll(bool trackChanges)
    {
      return FindAll(trackChanges).Include(h => h.Guests).Include(h => h.Services).ToList();
    }

    public async Task<IEnumerable<Booking>> GetAllAsync(bool trackChanges)
    {
      return await FindAll(trackChanges).Include(h => h.Guests).Include(h => h.Services).ToListAsync();    
    }

    public IEnumerable<Booking> GetByCondition(Expression<Func<Booking, bool>> expression, bool trackChanges)
    {
      return FindByCondition(expression, trackChanges).Include(h => h.Guests).Include(h => h.Services);
    }

    public Task<Booking?> GetOneAsync(Expression<Func<Booking, bool>> expression, bool trackChanges = false)
    {
      return FindOneAsync(expression, trackChanges);
    }

    public void CreateEntity(Booking entity) => Create(entity);
    public async Task CreateEntityAsync(Booking entity) => await CreateAsync(entity);
    public void UpdateEntity(Booking entity) => Update(entity);
    public void DeleteEntity(Booking entity) => Delete(entity);
    public async Task DeleteEntityRangeAsync(IEnumerable<Booking> entities)
    {
      await DeleteRangeAsync(entities);
    }
  }
}
