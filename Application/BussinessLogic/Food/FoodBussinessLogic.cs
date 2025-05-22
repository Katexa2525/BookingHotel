using Application.DTO.Food;
using Application.DTO.Price;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using FoodEntity = Domain.Models.Food;

namespace Application.BussinessLogic.Food
{
  public class FoodBussinessLogic : IFoodBussinessLogic
  {
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repositoryManager;

    public FoodBussinessLogic(IMapper mapper, IRepositoryManager repositoryManager)
    {
      _mapper = mapper;
      _repositoryManager = repositoryManager;
    }

    public async Task<List<FoodDto>> GetAllAsync(bool trackChanges)
    {
      return await _repositoryManager.FoodRepository.GetAll(trackChanges).AsQueryable()
                                  .ProjectTo<FoodDto>(_mapper.ConfigurationProvider)
                                  .ToListAsync();
    }

    public async Task<FoodDto> GetByIdAsync(Guid id, bool trackChanges)
    {
      //var food = await _repositoryFood.FindOneAsync(x => x.Id == id);
      var food = await _repositoryManager.FoodRepository.GetOneAsync(x => x.Id == id);

      return _mapper.Map<FoodDto>(food);
    }

    public async Task<Guid> CreateAsync(FoodCreateWithIdDto dto)
    {
      var entity = _mapper.Map<FoodEntity>(dto);
      entity.Id = Guid.NewGuid();
      await _repositoryManager.FoodRepository.CreateEntityAsync(entity);
      return entity.Id;
    }

    public async Task DeleteAsync(Guid foodId)
    {
      //var food = await _repositoryFood.FindOneAsync(x => x.Id == foodId);
      var food = await _repositoryManager.FoodRepository.GetOneAsync(x => x.Id == foodId);

      _repositoryManager.FoodRepository.DeleteEntity(food);
      await _repositoryManager.SaveAsync();
    }

    public async Task UpdateAsync(FoodDto dto)
    {
      //var existingFood = await _repositoryFood.FindOneAsync(x => x.Id == dto.Id);
      var existingFood = await _repositoryManager.FoodRepository.GetOneAsync(x => x.Id == dto.Id);

      _mapper.Map(dto, existingFood);

      _repositoryManager.FoodRepository.UpdateEntity(existingFood);
      await _repositoryManager.SaveAsync();
    }

    public List<FoodDto> GetByCondition(Expression<Func<FoodEntity, bool>> expression, bool trackChanges)
    {
      return _repositoryManager.FoodRepository.GetByCondition(expression, trackChanges).AsQueryable()
                                  .ProjectTo<FoodDto>(_mapper.ConfigurationProvider)
                                  .ToList();
    }
  }
}
