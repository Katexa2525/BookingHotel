using Application.DTO.Room;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RoomEntity = Domain.Models.Room;

namespace Application.BussinessLogic.Room
{
  public class RoomBussinessLogic : IRoomBussinessLogic
  {
    private readonly IRepositoryBase<RoomEntity> _repository;
    private readonly IMapper _mapper;

    public RoomBussinessLogic(IRepositoryBase<RoomEntity> repository)
    {
      _repository = repository;
    }

    public async Task<List<RoomDto>> GetAllAsync()
    {
      return await _repository.FindAll().ProjectTo<RoomDto>(_mapper.ConfigurationProvider)
                                        .ToListAsync();
    }
  }
}
