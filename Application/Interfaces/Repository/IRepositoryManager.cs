namespace Application.Interfaces.Repository
{
  public interface IRepositoryManager
  {
    IRoomRepository RoomRepository { get; }

    Task SaveAsync();
    void Save();
  }
}
