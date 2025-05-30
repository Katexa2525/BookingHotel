using Application.DTO.HotelPhoto;
using System.Linq.Expressions;

namespace Application.BussinessLogic.HotelPhoto
{
  public interface IHotelPhotoBussinessLogic
  {
    Task<Guid> CreateAsync(HotelPhotoCreateWithIdDto dto);
    Task DeleteAsync(Guid hotelPhotoId);
    Task UpdateAsync(HotelPhotoDto dto);
    Task<HotelPhotoDto> GetByIdAsync(Guid id, bool trackChanges);
    List<HotelPhotoDto> GetByCondition(Expression<Func<Domain.Models.HotelPhoto, bool>> expression, bool trackChanges);
  }
}
