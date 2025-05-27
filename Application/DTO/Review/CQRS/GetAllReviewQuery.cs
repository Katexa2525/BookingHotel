using MediatR;

namespace Application.DTO.Review.CQRS
{
  public class GetAllReviewQuery : IRequest<List<ReviewDto>>
  {
  }
}
