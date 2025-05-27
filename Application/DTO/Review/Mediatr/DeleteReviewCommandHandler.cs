using Application.BussinessLogic.Review;
using Application.DTO.Review.CQRS;
using MediatR;

namespace Application.DTO.Review.Mediatr
{
  public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, Unit>
  {
    private readonly IReviewBussinessLogic _bussinessLogic;

    public DeleteReviewCommandHandler(IReviewBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
      await _bussinessLogic.DeleteAsync(request.ReviewId);
      return Unit.Value;
    }
  }
}
