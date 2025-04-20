using Application.DTO.Food;
using Application.DTO.Hotel;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using FoodEntity = Domain.Models.Food;

namespace Application.BussinessLogic.Food
{
  public class FoodBussinessLogic : IFoodBussinessLogic
  {
    //private readonly IRepositoryBase<FoodEntity> _repositoryFood;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repositoryManager;

    public FoodBussinessLogic(/*IRepositoryBase<FoodEntity> repositoryFood,*/ IMapper mapper, IRepositoryManager repositoryManager)
    {
      //_repositoryFood = repositoryFood;
      _mapper = mapper;
      _repositoryManager = repositoryManager;
    }

    public async Task<List<FoodDto>> GetAllAsync()
    {
      //return await _repositoryFood.FindAll()
      //                             .ProjectTo<FoodDto>(_mapper.ConfigurationProvider)
      //                             .ToListAsync();

      return await _repositoryManager.FoodRepository.GetAll(trackChanges: true).AsQueryable()
                                  .ProjectTo<FoodDto>(_mapper.ConfigurationProvider)
                                  .ToListAsync();
    }

    public async Task<FoodDto> GetByIdAsync(Guid id)
    {
      //var food = await _repositoryFood.FindOneAsync(x => x.Id == id);
      var food = await _repositoryManager.FoodRepository.GetOneAsync(x => x.Id == id);

      return _mapper.Map<FoodDto>(food);
    }

    public async Task<Guid> CreateAsync(FoodCreateWithIdDto dto)
    {
      var entity = _mapper.Map<FoodEntity>(dto);
      entity.Id = Guid.NewGuid();
      //await _repositoryFood.CreateAsync(entity);
      await _repositoryManager.FoodRepository.CreateEntityAsync(entity);
      return entity.Id;
    }

    public async Task DeleteAsync(Guid foodId)
    {
      //var food = await _repositoryFood.FindOneAsync(x => x.Id == foodId);
      var food = await _repositoryManager.FoodRepository.GetOneAsync(x => x.Id == foodId);

      //_repositoryFood.Delete(food);
      //await _repositoryFood.SaveAsync();

      _repositoryManager.FoodRepository.DeleteEntity(food);
      await _repositoryManager.SaveAsync();
    }

    public async Task UpdateAsync(FoodDto dto)
    {
      //var existingFood = await _repositoryFood.FindOneAsync(x => x.Id == dto.Id);
      var existingFood = await _repositoryManager.FoodRepository.GetOneAsync(x => x.Id == dto.Id);

      _mapper.Map(dto, existingFood);

      //_repositoryFood.Update(existingFood);
      //await _repositoryFood.SaveAsync();

      _repositoryManager.FoodRepository.UpdateEntity(existingFood);
      await _repositoryManager.SaveAsync();
    }
  }
}
