using Application.DTO.RoomType.CQRS;
using MediatR;

namespace Application.DTO.RoomType.Mediatr
{
  public class CreateRoomTypeCommandHandler : IRequestHandler<CreateRoomTypeCommand, Guid>
  {
    public Task<Guid> Handle(CreateRoomTypeCommand request, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}
