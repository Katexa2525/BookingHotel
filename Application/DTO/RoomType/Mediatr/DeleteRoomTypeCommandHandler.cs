using Application.DTO.Hotel.CQRS;
using Application.DTO.RoomType.CQRS;
using MediatR;

namespace Application.DTO.RoomType.Mediatr
{
  public class DeleteRoomTypeCommandHandler : IRequestHandler<DeleteRoomTypeCommand, Unit>
  {
    public Task<Unit> Handle(DeleteRoomTypeCommand request, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}
