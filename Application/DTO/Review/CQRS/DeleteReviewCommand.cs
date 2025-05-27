using MediatR;

namespace Application.DTO.Review.CQRS
{
  public class DeleteReviewCommand : IRequest<Unit>
  {
    public Guid ReviewId { get; set; }
  }
}
