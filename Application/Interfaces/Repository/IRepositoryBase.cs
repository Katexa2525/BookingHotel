using System.Linq.Expressions;

namespace Application.Interfaces.Repository
{
  public interface IRepositoryBase<T> where T : class
  {
    IQueryable<T> FindAll(bool trackChanges = false);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false);
    Task<T?> FindOneAsync(Expression<Func<T, bool>> expression, bool trackChanges = false);

    void Create(T entity);
    Task CreateAsync(T entity);

    void Update(T entity);
    void Delete(T entity);

    Task SaveAsync();
  }

}
