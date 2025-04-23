using Application.Interfaces.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
  public class TypeFoodRepository : RepositoryBase<TypeFood>, ITypeFoodRepository
  {
    private readonly RepositoryContext _repositoryContext;

    public TypeFoodRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }

    public IEnumerable<TypeFood> GetAll(bool trackChanges) => FindAll(trackChanges).ToList();

    public async Task<IEnumerable<TypeFood>> GetAllAsync(bool trackChanges) => await FindAll(trackChanges).ToListAsync();

    public IEnumerable<TypeFood> GetByCondition(Expression<Func<TypeFood, bool>> expression, bool trackChanges)
    {
      return FindByCondition(expression, trackChanges);
    }

    public Task<TypeFood?> GetOneAsync(Expression<Func<TypeFood, bool>> expression, bool trackChanges = false)
    {
      return FindOneAsync(expression, trackChanges);
    }

    public void CreateEntity(TypeFood entity) => Create(entity);
    public async Task CreateEntityAsync(TypeFood entity) => await CreateAsync(entity);
    public void UpdateEntity(TypeFood entity) => Update(entity);
    public void DeleteEntity(TypeFood entity) => Delete(entity);
    public async Task DeleteEntityRangeAsync(IEnumerable<TypeFood> entities)
    {
      await DeleteRangeAsync(entities);
    }
  }
}
