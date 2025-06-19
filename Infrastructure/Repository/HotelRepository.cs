using Application.Interfaces.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
  public class HotelRepository : RepositoryBase<Hotel>, IHotelRepository
  {
    private readonly RepositoryContext _repositoryContext;

    public HotelRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }

    public IEnumerable<Hotel> GetAll(bool trackChanges) => FindAll(trackChanges)
      .Include(h => h.HotelPhotos)
      .Include(h => h.Locations).Include(h => h.Foods)//.Include(h => h.HotelUsefulInfo)
      .Include(h => h.HotelFacilities).Include(h => h.Reviews).Include(h => h.Rooms)
      .ToList();

    public async Task<IEnumerable<Hotel>> GetAllAsync(bool trackChanges) => await FindAll(trackChanges)
      .Include(h => h.HotelPhotos)
      .Include(h => h.Locations).Include(h => h.Foods)//.Include(h => h.HotelUsefulInfo)
      .Include(h => h.HotelFacilities).Include(h => h.Reviews).Include(h => h.Rooms)
      .ToListAsync();

    public IEnumerable<Hotel> GetByCondition(Expression<Func<Hotel, bool>> expression, bool trackChanges)
    {
      return FindByCondition(expression, trackChanges)
             .Include(h=>h.Locations).Include(h => h.Foods).Include(h => h.HotelUsefulInfo)
             .Include(h => h.HotelFacilities).Include(h => h.HotelPhotos).Include(h => h.Reviews).Include(h => h.Rooms);
    }

    public Task<Hotel?> GetOneAsync(Expression<Func<Hotel, bool>> expression, bool trackChanges = false)
    {
      return FindOneAsync(expression, trackChanges);
    }

    public void CreateEntity(Hotel entity) => Create(entity);
    public async Task CreateEntityAsync(Hotel entity) => await CreateAsync(entity);
    public void UpdateEntity(Hotel entity) => Update(entity);
    public void DeleteEntity(Hotel entity) => Delete(entity);
    public async Task DeleteEntityRangeAsync(IEnumerable<Hotel> entities)
    {
      await DeleteRangeAsync(entities);
    }
  }
}
