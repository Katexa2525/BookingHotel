namespace Application.Interfaces.Repository
{
  public interface IRepositoryManager
  {
    //IHotelRepository HotelRepository { get; }

    Task SaveAsync();
    void Save();
  }
}
