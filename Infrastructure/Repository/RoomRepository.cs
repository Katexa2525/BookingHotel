using Application.Interfaces.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
  public class RoomRepository : RepositoryBase<Room>, IRoomRepository
  {
    private readonly RepositoryContext _repositoryContext;

    public RoomRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
      _repositoryContext = repositoryContext; 
    }

    public IEnumerable<Room> GetAll(bool trackChanges) => FindAll(trackChanges).ToList();

    public async Task<IEnumerable<Room>> GetAllAsync(bool trackChanges) => await FindAll(trackChanges).ToListAsync();

    public IEnumerable<Room> GetByCondition(Expression<Func<Room, bool>> expression, bool trackChanges)
    {
      return FindByCondition(expression, trackChanges);
    }

    public Task<Room?> GetOneAsync(Expression<Func<Room, bool>> expression, bool trackChanges = false)
    {
      return FindOneAsync(expression, trackChanges);
    }

    public void CreateEntity(Room entity) => Create(entity);
    public async Task CreateEntityAsync(Room entity) => await CreateAsync(entity);
    public void UpdateEntity(Room entity) => Update(entity);
    public void DeleteEntity(Room entity) => Delete(entity);
  }
}
