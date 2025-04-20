using Application.Interfaces.Repository;

namespace Infrastructure.Repository
{
    /// <summary>
    /// Класс менеджера репозитория, который создаст экземпляры пользовательских классов репозитория, а затем
    /// зарегистрирует их внутри контейнера внедрения зависимостей.После этого можно внедрить его внутри сервисов 
    /// с помощью внедрения конструктора(при поддержке ASP.NET Core). Имея класс менеджера репозитория, можно вызвать
    /// любой класс пользователя репозитория, который нам нужен.
    /// </summary>
    public sealed class RepositoryManager : IRepositoryManager
  {
    private readonly RepositoryContext _repositoryContext;

    private readonly Lazy<IRoomRepository> _roomRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
      _repositoryContext = repositoryContext;

      _roomRepository = new Lazy<IRoomRepository>(() => new RoomRepository(repositoryContext));
    }

    public IRoomRepository RoomRepository => _roomRepository.Value;

    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    public void Save() => _repositoryContext.SaveChanges();

  }
}
