using Application.DTO.HotelPhoto;
using Application.Interfaces.Repository;
using AutoMapper;
using HotelPhotoEntity = Domain.Models.HotelPhoto;

namespace Application.BussinessLogic.HotelPhoto
{
  public class HotelPhotoBussinessLogic : IHotelPhotoBussinessLogic
  {
    private readonly IRepositoryBase<HotelPhotoEntity> _repositoryHotelPhoto;
    private readonly IMapper _mapper;
    public HotelPhotoBussinessLogic(IRepositoryBase<HotelPhotoEntity> repositoryHotelPhoto,
      IMapper mapper)
    {
      _repositoryHotelPhoto = repositoryHotelPhoto;
      _mapper = mapper;
    }

    public async Task<Guid> CreateAsync(HotelPhotoCreateWithIdDto dto)
    {
      var entity = _mapper.Map<HotelPhotoEntity>(dto);
      entity.Id = Guid.NewGuid();
      await _repositoryHotelPhoto.CreateAsync(entity);
      return entity.Id;
    }

    public async Task DeleteAsync(Guid hotelPhotoId)
    {
      var hotelPhoto = await _repositoryHotelPhoto.FindOneAsync(x => x.Id == hotelPhotoId);
      _repositoryHotelPhoto.Delete(hotelPhoto);
      await _repositoryHotelPhoto.SaveAsync();
    }
  }
}
