using MediatR;

namespace Application.DTO.HotelPhoto.CQRS
{
  public class GetByIdHotelPhotoQuery : IRequest<HotelPhotoDto>
  {
    public Guid Id { get; set; }
  }
}
