using Application.BussinessLogic.Review;
using Application.DTO.Review.CQRS;
using MediatR;

namespace Application.DTO.Review.Mediatr
{
  public class GetAllReviewByHotelIdQueryHandler : IRequestHandler<GetAllReviewByHotelIdQuery, List<ReviewDto>>
  {
    private readonly IReviewBussinessLogic _bussinessLogic;

    public GetAllReviewByHotelIdQueryHandler(IReviewBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<List<ReviewDto>> Handle(GetAllReviewByHotelIdQuery request, CancellationToken cancellationToken)
    {
      return _bussinessLogic.GetByCondition(p => p.HotelId == request.HotelId, trackChanges: false);
    }
  }
}
