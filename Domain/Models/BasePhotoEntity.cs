using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
  public abstract class BasePhotoEntity
  {
    public Guid Id { get; set; }
    public byte[] Photo { get; set; }
  }
}
