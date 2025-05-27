using MediatR;

namespace Application.DTO.Review.ClientRequest
{
  public record GetReviewRequest(Guid reviewId) : IRequest<GetReviewRequest.Response>
  {
    public const string RouteTemplate = "api/reviews/{reviewId}";

    public record Response(ReviewDto? Review);
  }
}
