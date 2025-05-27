using MediatR;

namespace Application.DTO.Review.CQRS
{
  public class GetAllReviewByHotelIdQuery : IRequest<List<ReviewDto>>
  {
    public Guid HotelId { get; set; }
  }
}
