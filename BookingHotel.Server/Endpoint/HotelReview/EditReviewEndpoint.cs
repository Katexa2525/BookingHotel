using Application.ConstMessages;
using Application.DTO.Review;
using Application.DTO.Review.ClientRequest;
using Application.DTO.Review.CQRS;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Endpoint.HotelReview
{
  public class EditReviewEndpoint : BaseAsyncEndpoint.WithRequest<EditReviewRequest>.WithResponse<bool>
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public EditReviewEndpoint(IMediator mediator, IMapper mapper)
    {
      _mediator = mediator;
      _mapper = mapper;
    }

    [HttpPut(EditReviewRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(EditReviewRequest request, CancellationToken cancellationToken = default)
    {
      var roomPhoto = await _mediator.Send(new GetByIdReviewQuery() { Id = request.review.Id });

      if (roomPhoto is null)
      {
        return BadRequest(AppMessage.GetReviewByIdTextErrorMessage);
      }

      // обновляю модель данными из запроса
      roomPhoto.Star = request.review.Star;
      roomPhoto.Name = request.review.Name;
      roomPhoto.HotelId = request.review.HotelId;
      roomPhoto.DateTimeReview = request.review.DateTimeReview;
      roomPhoto.Description = request.review.Description;

      // сохраняю изменения
      var result = await _mediator.Send(new UpdateReviewCommand() { Dto = _mapper.Map<ReviewDto>(roomPhoto) });

      return Ok(true);
    }
  }
}
