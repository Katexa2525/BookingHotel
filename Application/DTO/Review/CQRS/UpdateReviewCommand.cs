using MediatR;

namespace Application.DTO.Review.CQRS
{
  public class UpdateReviewCommand : IRequest<Unit>
  {
    public ReviewDto Dto { get; set; }
  }
}
