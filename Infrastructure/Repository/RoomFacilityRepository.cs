using Application.Interfaces.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
  public class RoomFacilityRepository : RepositoryBase<RoomFacility>, IRoomFacilityRepository
  {
    private readonly RepositoryContext _repositoryContext;

    public RoomFacilityRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }

    public IEnumerable<RoomFacility> GetAll(bool trackChanges) => FindAll(trackChanges).ToList();

    public async Task<IEnumerable<RoomFacility>> GetAllAsync(bool trackChanges) => await FindAll(trackChanges).ToListAsync();

    public IEnumerable<RoomFacility> GetByCondition(Expression<Func<RoomFacility, bool>> expression, bool trackChanges)
    {
      return FindByCondition(expression, trackChanges);
    }

    public Task<RoomFacility?> GetOneAsync(Expression<Func<RoomFacility, bool>> expression, bool trackChanges = false)
    {
      return FindOneAsync(expression, trackChanges);
    }

    public void CreateEntity(RoomFacility entity) => Create(entity);
    public async Task CreateEntityAsync(RoomFacility entity) => await CreateAsync(entity);
    public void UpdateEntity(RoomFacility entity) => Update(entity);
    public void DeleteEntity(RoomFacility entity) => Delete(entity);
    public async Task DeleteEntityRangeAsync(IEnumerable<RoomFacility> entities)
    {
      await DeleteRangeAsync(entities);
    }
  }
}
