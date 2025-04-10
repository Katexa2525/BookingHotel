using Application.Interfaces.Repository;
using AutoMapper;

namespace Application.BussinessLogic.GeneralMethods
{
  public class GeneralBussinessLogic : IGeneralBussinessLogic
  {
    private readonly IMapper _mapper;

    public GeneralBussinessLogic(IMapper mapper)
    {
      _mapper = mapper;
    }

    public async Task UpdateCollectionAsync<TEntity, TDto>(
        IEnumerable<TEntity> existingItems,
        IEnumerable<TDto> updatedItems,
        IRepositoryBase<TEntity> repository,
        Action<TEntity, Guid> setParentId,
        Func<TEntity, Guid> getEntityId,
        Func<TDto, Guid> getDtoId)
        where TEntity : class
    {
      var existingItemsList = existingItems.ToList();

      foreach (var updatedItem in updatedItems)
      {
        var updatedId = getDtoId(updatedItem);
        var existingItem = existingItemsList.FirstOrDefault(e => getEntityId(e) == updatedId);

        if (existingItem != null)
        {
          _mapper.Map(updatedItem, existingItem);
          repository.Update(existingItem);
        }
        else
        {
          var newEntity = _mapper.Map<TEntity>(updatedItem);
          setParentId(newEntity, getEntityId(existingItemsList.First()));
          await repository.CreateAsync(newEntity);
        }
      }

      foreach (var existingItem in existingItemsList)
      {
        if (!updatedItems.Any(x => getDtoId(x) == getEntityId(existingItem)))
        {
          repository.Delete(existingItem);
        }
      }
    }
  }
}
