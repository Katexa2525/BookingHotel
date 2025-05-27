using MediatR;

namespace Application.DTO.Review.ClientRequest
{
  public record EditReviewRequest(ReviewDto review) : IRequest<EditReviewRequest.Response>
  {
    public const string RouteTemplate = "api/reviews/edit";
    public record Response(bool IsSuccess);
  }
}
