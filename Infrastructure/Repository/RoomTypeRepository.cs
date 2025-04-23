using Application.Interfaces.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
  public class RoomTypeRepository : RepositoryBase<RoomType>, IRoomTypeRepository
  {
    private readonly RepositoryContext _repositoryContext;

    public RoomTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }

    public IEnumerable<RoomType> GetAll(bool trackChanges) => FindAll(trackChanges).ToList();

    public async Task<IEnumerable<RoomType>> GetAllAsync(bool trackChanges) => await FindAll(trackChanges).ToListAsync();

    public IEnumerable<RoomType> GetByCondition(Expression<Func<RoomType, bool>> expression, bool trackChanges)
    {
      return FindByCondition(expression, trackChanges);
    }

    public Task<RoomType?> GetOneAsync(Expression<Func<RoomType, bool>> expression, bool trackChanges = false)
    {
      return FindOneAsync(expression, trackChanges);
    }

    public void CreateEntity(RoomType entity) => Create(entity);
    public async Task CreateEntityAsync(RoomType entity) => await CreateAsync(entity);
    public void UpdateEntity(RoomType entity) => Update(entity);
    public void DeleteEntity(RoomType entity) => Delete(entity);
    public async Task DeleteEntityRangeAsync(IEnumerable<RoomType> entities)
    {
      await DeleteRangeAsync(entities);
    }
  }
}
