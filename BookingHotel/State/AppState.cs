using Blazored.LocalStorage;

namespace BookingHotel.State
{
  public class AppState
  {
    private bool _isInitialized;

    public FavoriteHotelsState FavoriteHotelsState { get; }

    public AppState(ILocalStorageService localStorageService)
    {
      //FavoriteHotelsState передаю в ILocalStorageService
      FavoriteHotelsState = new FavoriteHotelsState(localStorageService);
    }

    /// <summary>Метод Initialize предоставляет основное место для инициализации любых дочерних хранилищ состояний</summary>
    public async Task Initialize()
    {
      if (!_isInitialized)
      {
        // Инициализация хранилища
        await FavoriteHotelsState.Initialize();
        _isInitialized = true;
      }
    }

  }
}
