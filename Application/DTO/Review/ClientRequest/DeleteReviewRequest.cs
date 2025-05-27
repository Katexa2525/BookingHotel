using MediatR;

namespace Application.DTO.Review.ClientRequest
{
  public record DeleteReviewRequest(Guid reviewId) : IRequest<DeleteReviewRequest.Response>
  {
    public const string RouteTemplate = "api/reviews/{reviewId}";

    public record Response(bool IsSuccess);
  }
}
