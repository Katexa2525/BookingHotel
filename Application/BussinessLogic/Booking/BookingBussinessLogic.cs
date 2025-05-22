using Application.DTO.Booking;
using Application.Interfaces.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq.Expressions;
using BookingEntity = Domain.Models.Booking;

namespace Application.BussinessLogic.Booking
{
  public class BookingBussinessLogic : IBookingBussinessLogic
  {
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public BookingBussinessLogic(IRepositoryManager repositoryManager, IMapper mapper)
    {
      _repositoryManager = repositoryManager;
      _mapper = mapper;
    }

    public async Task<List<BookingAllDto>> GetAllAsync(bool trackChanges)
    {
      var listDB = _mapper.Map<List<BookingAllDto>>(await _repositoryManager.BookingRepository.GetAllAsync(trackChanges));
      return listDB.ToList();
    }

    public async Task<BookingDto> GetByIdAsync(Guid id, bool trackChanges)
    {
      var booking = _repositoryManager.BookingRepository.GetByCondition(x => x.Id == id, trackChanges).FirstOrDefault();
      if (booking == null)
        return null;  
      else
        return _mapper.Map<BookingDto>(booking);
    }

    public async Task<Guid> CreateAsync(BookingCreateDto dto)
    {
      var entity = _mapper.Map<BookingEntity>(dto);
      entity.Id = Guid.NewGuid();
      foreach (var item in entity.Guests)
        item.BookingId = entity.Id;
      foreach (var item in entity.Services)
        item.BookingId = entity.Id;
      
      await _repositoryManager.BookingRepository.CreateEntityAsync(entity);
      await _repositoryManager.SaveAsync();
      return entity.Id;
    }

    public async Task DeleteAsync(Guid id)
    {
      var booking = await _repositoryManager.BookingRepository.GetOneAsync(x => x.Id == id, trackChanges: true);
      //var hotel = _repositoryManager.HotelRepository.GetByCondition(x => x.Id == hotelId, trackChanges: false).FirstOrDefault();

      if (booking is not null)
      {
        //if (booking.Guests is not null)
        //  await _repositoryManager.BookingRepository.DeleteEntityRangeAsync(booking.Guests);
        //if (booking.Services is not null)
        //  await _repositoryManager.BookingRepository.DeleteEntityRangeAsync(booking.Services);

        _repositoryManager.BookingRepository.DeleteEntity(booking);
        await _repositoryManager.SaveAsync();
      }
    }

    public async Task UpdateAsync(BookingUpdateDto dto)
    {
      var entity = await _repositoryManager.BookingRepository.GetOneAsync(x => x.Id == dto.Id, trackChanges: true);
      if (entity == null) return;

      _mapper.Map(dto, entity);

      _repositoryManager.BookingRepository.UpdateEntity(entity);
      await _repositoryManager.SaveAsync();

      //await _generalBussinessLogic.UpdateCollectionAsync(
      //      entity.Guests,
      //      dto.Guests,
      //      //_repositoryRoom,
      //      null,
      //      (item, Id) => item.BookingId = Id,
      //      guest => guest.Id,
      //      dto => dto.Id
      //      );

      //await _generalBussinessLogic.UpdateCollectionAsync(
      //      entity.Services,
      //      dto.Services,
      //      //_repositoryFood,
      //      null,
      //      (item, Id) => item.BookingId = Id,
      //      serv => serv.Id,
      //      dto => dto.Id
      //      );
    }

    public List<BookingDto> GetByCondition(Expression<Func<BookingEntity, bool>> expression, bool trackChanges)
    {
      return _repositoryManager.BookingRepository.GetByCondition(expression, trackChanges).AsQueryable()
                                   .ProjectTo<BookingDto>(_mapper.ConfigurationProvider)
                                   .ToList();
    }
  }
}
