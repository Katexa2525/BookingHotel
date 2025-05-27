using MediatR;

namespace Application.DTO.Review.CQRS
{
  public class CreateReviewCommand : IRequest<Guid>
  {
    public ReviewCreateWithIdDto Dto { get; set; }
  }
}
