using Domain.Models;

namespace Application.Interfaces.Repository
{
  public interface IHotelRepository : IGeneralRepository<Hotel>
  {
    IQueryable<Hotel> GetHotelListQuery(bool trackChanges);
  }
}
