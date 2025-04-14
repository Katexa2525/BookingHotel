using Application.DTO.Food;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using FoodEntity = Domain.Models.Food;

namespace Application.BussinessLogic.Food
{
  public class FoodBussinessLogic : IFoodBussinessLogic
  {
    private readonly IRepositoryBase<FoodEntity> _repositoryFood;
    private readonly IMapper _mapper;
    public FoodBussinessLogic(IRepositoryBase<FoodEntity> repositoryFood)
    {
      _repositoryFood = repositoryFood;
    }

    public async Task<List<FoodDto>> GetAllAsync()
    {
      return await _repositoryFood.FindAll()
                                   .ProjectTo<FoodDto>(_mapper.ConfigurationProvider)
                                   .ToListAsync();
    }

    public async Task<FoodDto> GetByIdAsync(Guid id)
    {
      var food = await _repositoryFood.FindOneAsync(x => x.Id == id);
      return _mapper.Map<FoodDto>(food);
    }

    public async Task<Guid> CreateAsync(FoodCreateWithIdDto dto)
    {
      var entity = _mapper.Map<FoodEntity>(dto);
      entity.Id = Guid.NewGuid();
      await _repositoryFood.CreateAsync(entity);
      return entity.Id;
    }

    public async Task DeleteAsync(Guid foodId)
    {
      var food = await _repositoryFood.FindOneAsync(x => x.Id == foodId);
      _repositoryFood.Delete(food);
      await _repositoryFood.SaveAsync();
    }

    public async Task UpdateAsync(FoodDto dto)
    {
      var existingFood = await _repositoryFood.FindOneAsync(x => x.Id == dto.Id);
      _mapper.Map(dto, existingFood);
      _repositoryFood.Update(existingFood);
      await _repositoryFood.SaveAsync();
    }
  }
}
