using MediatR;

namespace Application.DTO.HotelPhoto.CQRS
{
  public class CreateHotelPhotoCommand : IRequest<Guid>
  {
    public HotelPhotoCreateWithIdDto Dto { get; set; }
  }
}
