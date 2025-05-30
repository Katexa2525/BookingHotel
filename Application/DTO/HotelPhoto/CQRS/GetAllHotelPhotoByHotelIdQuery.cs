using MediatR;

namespace Application.DTO.HotelPhoto.CQRS
{
  public class GetAllHotelPhotoByHotelIdQuery : IRequest<List<HotelPhotoDto>>
  {
    public Guid HotelId { get; set; }
  }
}
