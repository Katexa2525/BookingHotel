using Application.DTO.Hotel;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using HotelEntity = Domain.Models.Hotel;

namespace Application.BussinessLogic.Hotel
{
  public class HotelBussinessLogic : IHotelBussinessLogic
    {
        private readonly IRepositoryBase<HotelEntity> _repository;
        private readonly IMapper _mapper;

        public HotelBussinessLogic(IRepositoryBase<HotelEntity> repository)
        {
            _repository = repository;
        }

        public async Task<List<HotelDto>> GetAllAsync()
        {
            return await _repository.FindAll().ProjectTo<HotelDto>(_mapper.ConfigurationProvider)
                                              .ToListAsync();
        }
    }
}
