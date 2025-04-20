using Application.Interfaces.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
  public class RoomPhotoRepository : RepositoryBase<RoomPhoto>, IRoomPhotoRepository
  {
    private readonly RepositoryContext _repositoryContext;

    public RoomPhotoRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }

    public IEnumerable<RoomPhoto> GetAll(bool trackChanges) => FindAll(trackChanges).ToList();

    public async Task<IEnumerable<RoomPhoto>> GetAllAsync(bool trackChanges) => await FindAll(trackChanges).ToListAsync();

    public IEnumerable<RoomPhoto> GetByCondition(Expression<Func<RoomPhoto, bool>> expression, bool trackChanges)
    {
      return FindByCondition(expression, trackChanges);
    }

    public Task<RoomPhoto?> GetOneAsync(Expression<Func<RoomPhoto, bool>> expression, bool trackChanges = false)
    {
      return FindOneAsync(expression, trackChanges);
    }

    public void CreateEntity(RoomPhoto entity) => Create(entity);
    public async Task CreateEntityAsync(RoomPhoto entity) => await CreateAsync(entity);
    public void UpdateEntity(RoomPhoto entity) => Update(entity);
    public void DeleteEntity(RoomPhoto entity) => Delete(entity);
    public async Task DeleteEntityRangeAsync(IEnumerable<RoomPhoto> entities)
    {
      await DeleteRangeAsync(entities);
    }
  }
}
