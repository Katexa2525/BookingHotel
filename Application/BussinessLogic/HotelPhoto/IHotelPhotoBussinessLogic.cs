using Application.DTO.HotelPhoto;

namespace Application.BussinessLogic.HotelPhoto
{
  public interface IHotelPhotoBussinessLogic
  {
    Task<Guid> CreateAsync(HotelPhotoCreateWithIdDto dto);
    Task DeleteAsync(Guid hotelPhotoId);
  }
}
