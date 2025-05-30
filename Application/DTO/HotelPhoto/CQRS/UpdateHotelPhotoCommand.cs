using MediatR;

namespace Application.DTO.HotelPhoto.CQRS
{
  public class UpdateHotelPhotoCommand : IRequest<Unit>
  {
    public HotelPhotoDto Dto { get; set; }
  }
}
