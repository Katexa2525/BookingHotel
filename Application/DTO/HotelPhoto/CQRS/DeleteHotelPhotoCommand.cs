using MediatR;

namespace Application.DTO.HotelPhoto.CQRS
{
  public class DeleteHotelPhotoCommand : IRequest<Unit>
  {
    public Guid HotelPhotoId { get; set; }
  }
}
