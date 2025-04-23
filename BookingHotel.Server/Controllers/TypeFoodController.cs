using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Server.Controllers
{
  [ApiController]
  [Route("typefood")]
  public class TypeFoodController
  {
    private readonly IMediator _mediator;
    public TypeFoodController(IMediator mediator)
    {
      _mediator = mediator;
    }
  }
}
