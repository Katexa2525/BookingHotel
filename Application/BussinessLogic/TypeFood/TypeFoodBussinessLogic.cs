using Application.DTO.Hotel;
using Application.DTO.TypeFood;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TypyFoodEntity = Domain.Models.TypeFood;

namespace Application.BussinessLogic.TypeFood
{
  public class TypeFoodBussinessLogic : ITypeFoodBussinessLogic
  {
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repositoryManager;

    public TypeFoodBussinessLogic(IMapper mapper, IRepositoryManager repositoryManager)
    {
      _mapper = mapper;
      _repositoryManager = repositoryManager;
    }

    public async Task<List<TypeFoodDto>> GetAllAsync(bool trackChanges)
    {
      //return await _repositoryManager.TypeFoodRepository.GetAll(trackChanges).AsQueryable()
      //                                                  .ProjectTo<TypeFoodDto>(_mapper.ConfigurationProvider)
      //                                                  .ToListAsync();

      var listDB = _mapper.Map<List<TypeFoodDto>>(await _repositoryManager.TypeFoodRepository.GetAllAsync(trackChanges));
      return listDB.ToList();
    }

    public async Task<TypeFoodDto> GetByIdAsync(Guid id, bool trackChanges)
    {
      var typeFood = await _repositoryManager.TypeFoodRepository.GetOneAsync(x => x.Id == id);

      return _mapper.Map<TypeFoodDto>(typeFood);
    }

    public async Task<Guid> CreateAsync(TypeFoodCreateWithIdDto dto)
    {
      var entity = _mapper.Map<TypyFoodEntity>(dto);
      entity.Id = Guid.NewGuid();
      await _repositoryManager.TypeFoodRepository.CreateEntityAsync(entity);
      await _repositoryManager.SaveAsync();
      return entity.Id;
    }

    public async Task DeleteAsync(Guid typefoodId)
    {
      var typefood = await _repositoryManager.TypeFoodRepository.GetOneAsync(x => x.Id == typefoodId);

      _repositoryManager.TypeFoodRepository.DeleteEntity(typefood);
      await _repositoryManager.SaveAsync();
    }

    public async Task UpdateAsync(TypeFoodDto dto)
    {
      var existingTypeFood = await _repositoryManager.TypeFoodRepository.GetOneAsync(x => x.Id == dto.Id);

      _mapper.Map(dto, existingTypeFood);

      _repositoryManager.TypeFoodRepository.UpdateEntity(existingTypeFood);
      await _repositoryManager.SaveAsync();
    }

    public List<TypeFoodDto> GetByCondition(Expression<Func<TypyFoodEntity, bool>> expression, bool trackChanges)
    {
      return _repositoryManager.TypeFoodRepository.GetByCondition(expression, trackChanges).AsQueryable()
                                                  .ProjectTo<TypeFoodDto>(_mapper.ConfigurationProvider)
                                                  .ToList();
    }
  }
}
