using Application.Interfaces.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
  public class HotelPhotoRepository : RepositoryBase<HotelPhoto>, IHotelPhotoRepository
  {
    private readonly RepositoryContext _repositoryContext;

    public HotelPhotoRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }

    public IEnumerable<HotelPhoto> GetAll(bool trackChanges) => FindAll(trackChanges).ToList();

    public async Task<IEnumerable<HotelPhoto>> GetAllAsync(bool trackChanges) => await FindAll(trackChanges).ToListAsync();

    public IEnumerable<HotelPhoto> GetByCondition(Expression<Func<HotelPhoto, bool>> expression, bool trackChanges)
    {
      return FindByCondition(expression, trackChanges);
    }

    public Task<HotelPhoto?> GetOneAsync(Expression<Func<HotelPhoto, bool>> expression, bool trackChanges = false)
    {
      return FindOneAsync(expression, trackChanges);
    }

    public void CreateEntity(HotelPhoto entity) => Create(entity);
    public async Task CreateEntityAsync(HotelPhoto entity) => await CreateAsync(entity);
    public void UpdateEntity(HotelPhoto entity) => Update(entity);
    public void DeleteEntity(HotelPhoto entity) => Delete(entity);
    public async Task DeleteEntityRangeAsync(IEnumerable<HotelPhoto> entities)
    {
      await DeleteRangeAsync(entities);
    }
  }
}
