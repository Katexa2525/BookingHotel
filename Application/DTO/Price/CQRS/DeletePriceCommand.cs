using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Price.CQRS
{
  public class DeletePriceCommand : IRequest<Unit>
  {
    public Guid PriceId { get; set; }
  }
}
