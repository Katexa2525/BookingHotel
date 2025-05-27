using Application.BussinessLogic.Review;
using Application.DTO.Review.CQRS;
using MediatR;

namespace Application.DTO.Review.Mediatr
{
  public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, Unit>
  {
    private readonly IReviewBussinessLogic _bussinessLogic;

    public UpdateReviewCommandHandler(IReviewBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<Unit> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
      await _bussinessLogic.UpdateAsync(request.Dto);
      return Unit.Value;
    }
  }
}
