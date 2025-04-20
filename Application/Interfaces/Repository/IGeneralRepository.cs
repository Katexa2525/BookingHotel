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

    public void CreateEntity(Room entity);
    public Task CreateEntityAsync(Room entity);
    public void UpdateEntity(Room entity);
    public void DeleteEntity(Room entity);
  }
}
