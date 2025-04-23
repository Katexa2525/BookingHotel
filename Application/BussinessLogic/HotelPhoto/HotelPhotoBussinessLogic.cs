using Application.DTO.HotelPhoto;
using Application.Interfaces.Repository;
using AutoMapper;
using Domain.Models;
using HotelPhotoEntity = Domain.Models.HotelPhoto;

namespace Application.BussinessLogic.HotelPhoto
{
  public class HotelPhotoBussinessLogic : IHotelPhotoBussinessLogic
  {
    //private readonly IRepositoryBase<HotelPhotoEntity> _repositoryHotelPhoto;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repositoryManager;

    public HotelPhotoBussinessLogic(/*IRepositoryBase<HotelPhotoEntity> repositoryHotelPhoto,*/
                                    IMapper mapper,
                                    IRepositoryManager repositoryManager)
    {
      //_repositoryHotelPhoto = repositoryHotelPhoto;
      _mapper = mapper;
      _repositoryManager = repositoryManager;
    }

    public async Task<Guid> CreateAsync(HotelPhotoCreateWithIdDto dto)
    {
      var entity = _mapper.Map<HotelPhotoEntity>(dto);
      entity.Id = Guid.NewGuid();
      //await _repositoryHotelPhoto.CreateAsync(entity);
      await _repositoryManager.HotelPhotoRepository.CreateEntityAsync(entity);
      return entity.Id;
    }

    public async Task DeleteAsync(Guid hotelPhotoId)
    {
      //var hotelPhoto = await _repositoryHotelPhoto.FindOneAsync(x => x.Id == hotelPhotoId);
      //_repositoryHotelPhoto.Delete(hotelPhoto);
      //await _repositoryHotelPhoto.SaveAsync();

      var hotelPhoto = await _repositoryManager.HotelPhotoRepository.GetOneAsync(x => x.Id == hotelPhotoId);
      _repositoryManager.HotelPhotoRepository.DeleteEntity(hotelPhoto);
      await _repositoryManager.SaveAsync();
    }
  }
}
