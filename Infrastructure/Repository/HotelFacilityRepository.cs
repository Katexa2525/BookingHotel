using Application.Interfaces.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
  public class HotelFacilityRepository : RepositoryBase<HotelFacility>, IHotelFacilityRepository
  {
    private readonly RepositoryContext _repositoryContext;

    public HotelFacilityRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }

    public IEnumerable<HotelFacility> GetAll(bool trackChanges) => FindAll(trackChanges).ToList();

    public async Task<IEnumerable<HotelFacility>> GetAllAsync(bool trackChanges) => await FindAll(trackChanges).ToListAsync();

    public IEnumerable<HotelFacility> GetByCondition(Expression<Func<HotelFacility, bool>> expression, bool trackChanges)
    {
      return FindByCondition(expression, trackChanges);
    }

    public Task<HotelFacility?> GetOneAsync(Expression<Func<HotelFacility, bool>> expression, bool trackChanges = false)
    {
      return FindOneAsync(expression, trackChanges);
    }

    public void CreateEntity(HotelFacility entity) => Create(entity);
    public async Task CreateEntityAsync(HotelFacility entity) => await CreateAsync(entity);
    public void UpdateEntity(HotelFacility entity) => Update(entity);
    public void DeleteEntity(HotelFacility entity) => Delete(entity);
    public async Task DeleteEntityRangeAsync(IEnumerable<HotelFacility> entities)
    {
      await DeleteRangeAsync(entities);
    }
  }
}
