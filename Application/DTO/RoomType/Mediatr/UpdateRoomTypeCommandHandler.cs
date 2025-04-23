using Application.DTO.RoomType.CQRS;
using MediatR;

namespace Application.DTO.RoomType.Mediatr
{
  public class UpdateRoomTypeCommandHandler : IRequestHandler<UpdateRoomTypeCommand, Unit>
  {
    public Task<Unit> Handle(UpdateRoomTypeCommand request, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}
