using Application.DTO.Food;
using System.Linq.Expressions;

namespace Application.BussinessLogic.Food
{
  public interface IFoodBussinessLogic
  {
    Task<List<FoodDto>> GetAllAsync(bool trackChanges);
    Task<FoodDto> GetByIdAsync(Guid id, bool trackChanges);
    Task<Guid> CreateAsync(FoodCreateWithIdDto dto);
    Task DeleteAsync(Guid foodId);
    Task UpdateAsync(FoodDto dto);
    List<FoodDto> GetByCondition(Expression<Func<Domain.Models.Food, bool>> expression, bool trackChanges);
  }
}
