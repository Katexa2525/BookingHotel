using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
  public class Hotel: BaseEntity
  {
    public string Description { get; set; }
    public double Rating { get; set; }
    public IEnumerable<Room> Rooms { get; set; }
  }
}
