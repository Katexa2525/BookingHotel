using Application.BussinessLogic.Review;
using Application.DTO.Review.CQRS;
using MediatR;

namespace Application.DTO.Review.Mediatr
{
  public class GetByIdReviewQueryHandler : IRequestHandler<GetByIdReviewQuery, ReviewDto>
  {
    private readonly IReviewBussinessLogic _bussinessLogic;

    public GetByIdReviewQueryHandler(IReviewBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<ReviewDto> Handle(GetByIdReviewQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetByIdAsync(request.Id, trackChanges: false);
    }
  }
}
