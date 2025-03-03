using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
  public class Price
  {
    public Guid Id { get; set; }  
    public Guid RoomId { get; set; }
    public Room Room { get; set; }
  }
}
