using MediatR;

namespace Application.DTO.Review.ClientRequest
{
  public record AddReviewRequest(ReviewCreateWithIdDto Review) : IRequest<AddReviewRequest.Response>
  {
    public const string RouteTemplate = "api/reviews/create";

    public record Response(Guid reviewId);
  }
}
