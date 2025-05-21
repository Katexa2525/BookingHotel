using Application.BussinessLogic.Guest;
using Application.DTO.Guest.CQRS;
using MediatR;

namespace Application.DTO.Guest.Mediatr
{
  public class UpdateGuestCommandHandler : IRequestHandler<UpdateGuestCommand, Unit>
  {
    private readonly IGuestBussinessLogic _bussinessLogic;

    public UpdateGuestCommandHandler(IGuestBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<Unit> Handle(UpdateGuestCommand request, CancellationToken cancellationToken)
    {
      await _bussinessLogic.UpdateAsync(request.Dto);
      return Unit.Value;
    }
  }
}
