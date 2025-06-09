using Application.DTO.TypeFood;
using System.Linq.Expressions;

namespace Application.BussinessLogic.TypeFood
{
  public interface ITypeFoodBussinessLogic
  {
    Task<List<TypeFoodDto>> GetAllAsync(bool trackChanges);
    Task<TypeFoodDto> GetByIdAsync(Guid id, bool trackChanges);
    Task<Guid> CreateAsync(TypeFoodCreateWithIdDto dto);
    Task DeleteAsync(Guid foodId);
    Task UpdateAsync(TypeFoodDto dto);
    List<TypeFoodDto> GetByCondition(Expression<Func<Domain.Models.TypeFood, bool>> expression, bool trackChanges);
  }
}
