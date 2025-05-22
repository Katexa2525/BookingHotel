using Application.DTO.Price;
using System.Linq.Expressions;

namespace Application.BussinessLogic.Price
{
  public interface IPriceBussinessLogic
  {
    Task<List<PriceDto>> GetAllAsync(bool trackChanges);
    Task<PriceDto> GetByIdAsync(Guid id, bool trackChanges);
    Task<Guid> CreateAsync(PriceCreateWithIdDto dto);
    Task DeleteAsync(Guid priceId);
    Task UpdateAsync(PriceDto dto);
    List<PriceDto> GetByCondition(Expression<Func<Domain.Models.Price, bool>> expression, bool trackChanges);
  }
}
