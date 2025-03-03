namespace Domain.Models
{
  public abstract class BasePhotoEntity
  {
    public Guid Id { get; set; }
    public byte[] Photo { get; set; }
  }
}
