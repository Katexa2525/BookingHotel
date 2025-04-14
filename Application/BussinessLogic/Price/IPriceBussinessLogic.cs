using Application.DTO.Price;

namespace Application.BussinessLogic.Price
{
  public interface IPriceBussinessLogic
  {
    Task<List<PriceDto>> GetAllAsync();
    Task<PriceDto> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(PriceCreateWithIdDto dto);
    Task DeleteAsync(Guid priceId);
    Task UpdateAsync(PriceDto dto);
  }
}
