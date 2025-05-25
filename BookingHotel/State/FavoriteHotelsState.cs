using Application.DTO.Hotel;
using Blazored.LocalStorage;

namespace BookingHotel.State
{
  public class FavoriteHotelsState
  {
    private const string favoriteHotelsKey = "favoriteHotels";
    private bool _isInitialized;
    private readonly ILocalStorageService _localStorageService;

    /// <summary> Текущие избранные отели хранятся в закрытом списке, поэтому ими нельзя управлять напрямую </summary>
    private List<HotelDto> _favoriteHotels = new();

    /// <summary>Избранные отели отображаются в виде списка, доступного только для чтения </summary>
    public IReadOnlyList<HotelDto> FavoriteHotels => _favoriteHotels.AsReadOnly();

    /// <summary>Событие OnChange позволяет заинтересованным компонентам подписываться на изменения в хранилище  /// </summary>
    public event Action? OnChange;

    /// <summary>
    /// Интерфейс ILocalStorageService предоставляется пакетом Blazored.LocalStorage
    /// и дает возможность чтения и записи в локальное хранилище браузера
    /// </summary>
    public FavoriteHotelsState(ILocalStorageService localStorageService)
    {
      _localStorageService = localStorageService;
    }

    /// <summary>Метод инициализации будет вызываться при первоначальной загрузке приложения для настройки хранилища </summary>
    public async Task Initialize()
    {
      if (!_isInitialized)
      {
        _favoriteHotels = await _localStorageService.GetItemAsync<List<HotelDto>>(favoriteHotelsKey) ?? new List<HotelDto>();
        _isInitialized = true;
        NotifyStateHasChanged();
      }
    }

    /// <summary> Добавляет отель в список избранных и сохраняет копию списка 
    /// избранных отелей в локальное хранилище.В конце вызывает метод 
    /// NotifyStateHasChanged, который отвечает за запуск события OnChange
    /// </summary>
    public async Task AddFavorite(HotelDto hotel)
    {
      if (_favoriteHotels.Any(_ => _.Id == hotel.Id)) 
        return;
      _favoriteHotels.Add(hotel);
      await _localStorageService.SetItemAsync(favoriteHotelsKey, _favoriteHotels);
      NotifyStateHasChanged();
    }

    /// <summary>
    /// Данный метод будет выполнять действие, обратное методу AddFavorite.  
    /// Он удаляет отель из списка избранных и сохраняет обновление в локальном
    /// хранилище перед вызовом метода NotifyStateHasChanged
    /// </summary>
    public async Task RemoveFavorite(HotelDto hotel)
    {
      var existingHotel = _favoriteHotels.SingleOrDefault(_ => _.Id == hotel.Id);
      if (existingHotel is null) 
        return;
      _favoriteHotels.Remove(existingHotel);
      await _localStorageService.SetItemAsync(favoriteHotelsKey, _favoriteHotels);
      NotifyStateHasChanged();
    }

    /// <summary>
    /// Это простой вспомогательный метод, который будем использовать, чтобы проверить,
    /// является ли отель избранным
    /// </summary>
    public bool IsFavorite(HotelDto hotel) => _favoriteHotels.Any(_ => _.Id == hotel.Id);

    /// <summary>
    ///  Этот метод отвечает за запуск события OnChange, которое уведомляет подписчиков
    ///  о том, что в хранилище что-то изменилось
    /// </summary>
    private void NotifyStateHasChanged() => OnChange?.Invoke();

  }
}
