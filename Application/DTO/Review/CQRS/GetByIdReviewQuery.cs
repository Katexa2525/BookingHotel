using MediatR;

namespace Application.DTO.Review.CQRS
{
  public class GetByIdReviewQuery : IRequest<ReviewDto>
  {
    public Guid Id { get; set; }
  }
}
