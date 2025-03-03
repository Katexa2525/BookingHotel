using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
  public class Booking
  {
    public Guid Id { get; set; }
    public int NumberOfAdults { get; set; }
    public DateTime RaceDate { get; set; }
    public DateTime DepartureDate { get; set; }
  }
}
