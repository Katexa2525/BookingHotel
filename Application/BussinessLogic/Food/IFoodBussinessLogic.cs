using Application.DTO.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BussinessLogic.Food
{
  public interface IFoodBussinessLogic
  {
    Task<List<FoodDto>> GetAllAsync();
    Task<FoodDto> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(FoodCreateWithIdDto dto);
    Task DeleteAsync(Guid foodId);
    Task UpdateAsync(FoodDto dto);
  }
}
