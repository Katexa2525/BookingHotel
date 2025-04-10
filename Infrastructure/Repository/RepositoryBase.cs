using Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
  public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
  {
    protected readonly RepositoryContext RepositoryContext;

    public RepositoryBase(RepositoryContext repositoryContext) => RepositoryContext = repositoryContext;

    public IQueryable<T> FindAll(bool trackChanges = false) =>
        trackChanges ? RepositoryContext.Set<T>() : RepositoryContext.Set<T>().AsNoTracking();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false) =>
        trackChanges ? RepositoryContext.Set<T>().Where(expression) : RepositoryContext.Set<T>().Where(expression).AsNoTracking();

    public async Task<T?> FindOneAsync(Expression<Func<T, bool>> expression, bool trackChanges = false) =>
        await FindByCondition(expression, trackChanges).FirstOrDefaultAsync();

    public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
    public async Task CreateAsync(T entity) => await RepositoryContext.Set<T>().AddAsync(entity);

    public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

    public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

    public async Task DeleteRangeAsync(IEnumerable<T> entities)
    {
      RepositoryContext.Set<T>().RemoveRange(entities);
    }

    public async Task SaveAsync() => await RepositoryContext.SaveChangesAsync();
  }
}
