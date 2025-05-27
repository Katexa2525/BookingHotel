using MediatR;

namespace Application.DTO.Review.ClientRequest
{
  public record GetReviewsRequest(Guid hotelId) : IRequest<GetReviewsRequest.Response>
  {
    public const string RouteTemplate = "api/hotels/{hotelId}/reviews";

    public record Response(List<ReviewDto>? Reviews);
  }
}
