using Application.Interfaces.Repository;

namespace Application.BussinessLogic.GeneralMethods
{
  public interface IGeneralBussinessLogic
  {
    Task UpdateCollectionAsync<TEntity, TDto>(
        IEnumerable<TEntity> existingItems,
        IEnumerable<TDto> updatedItems,
        IRepositoryBase<TEntity> repository,
        Action<TEntity, Guid> setParentId,
        Func<TEntity, Guid> getEntityId,
        Func<TDto, Guid> getDtoId)
        where TEntity : class;
  }
}
