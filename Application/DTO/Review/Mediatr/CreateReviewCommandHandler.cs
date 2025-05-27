using Application.BussinessLogic.Review;
using Application.DTO.Review.CQRS;
using MediatR;

namespace Application.DTO.Review.Mediatr
{
  public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, Guid>
  {
    private readonly IReviewBussinessLogic _bussinessLogic;
    public CreateReviewCommandHandler(IReviewBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<Guid> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.CreateAsync(request.Dto);
    }
  }
}
