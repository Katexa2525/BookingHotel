using Application.BussinessLogic.Guest;
using Application.DTO.Guest.CQRS;
using MediatR;

namespace Application.DTO.Guest.Mediatr
{
  public class CreateGuestCommandHandler : IRequestHandler<CreateGuestCommand, Guid>
  {
    private readonly IGuestBussinessLogic _bussinessLogic;

    public CreateGuestCommandHandler(IGuestBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<Guid> Handle(CreateGuestCommand request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.CreateAsync(request.Dto);
    }
  }
}
