using Application.BussinessLogic.Review;
using Application.DTO.Review.CQRS;
using MediatR;

namespace Application.DTO.Review.Mediatr
{
  public class GetAllReviewQueryHandler : IRequestHandler<GetAllReviewQuery, List<ReviewDto>>
  {
    private readonly IReviewBussinessLogic _bussinessLogic;
    public GetAllReviewQueryHandler(IReviewBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<List<ReviewDto>> Handle(GetAllReviewQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetAllAsync(trackChanges: false); 
    }
  }
}
