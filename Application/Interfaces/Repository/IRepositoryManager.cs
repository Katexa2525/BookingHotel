namespace Application.Interfaces.Repository
{
  public interface IRepositoryManager
  {
    IRoomRepository RoomRepository { get; }
    IPriceRepository PriceRepository { get; }

    Task SaveAsync();
    void Save();
  }
}
