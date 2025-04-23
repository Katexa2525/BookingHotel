using Domain.Models;
using System.Linq.Expressions;

namespace Application.Interfaces.Repository
{
  /// <summary> Общий интерфейс для операций по всем сущностям </summary>
  /// <typeparam name="T"></typeparam>
  public interface IGeneralRepository<T>
  {
    IEnumerable<T> GetAll(bool trackChanges);
    Task<IEnumerable<T>> GetAllAsync(bool trackChanges);
    IEnumerable<T> GetByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
    Task<T?> GetOneAsync(Expression<Func<T, bool>> expression, bool trackChanges = false);

    public void CreateEntity(T entity);
    public Task CreateEntityAsync(T entity);
    public void UpdateEntity(T entity);
    public void DeleteEntity(T entity);
    public Task DeleteEntityRangeAsync(IEnumerable<T> entities);
  }
}
