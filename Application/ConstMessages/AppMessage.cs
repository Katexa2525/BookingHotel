namespace Application.ConstMessages
{
  public static class AppMessage
  {
    public static readonly string ValidatorHotelNameMessage = "Введите наименование отеля";
    public static readonly string ValidatorHotelDescriptionMessage = "Введите описание отеля";
    public static readonly string ValidatorHotelLocationMessage = "Введите местоположение отеля";
    public static readonly string ValidatorHotelStarMessage = "Введите кол-во звезд у отеля";
    public static readonly string ValidatorHotelArrivalMessage = "Введите время заезда отеля";
    public static readonly string ValidatorHotelDepartureMessage = "Введите время выезда отеля";

    public static readonly string ValidatorRoomSquareMessage = "Введите площадь номера отеля";
    public static readonly string ValidatorRoomDescriptionMessage = "Введите описание номера отеля";
    public static readonly string ValidatorRoomPeopleNumberMessage = "Введите кол-во человек номера отеля";

    public static readonly string HotelPageSaveTextErrorMessage = "Возникла проблема с сохранением отеля!";
    public static readonly string AddHotelPageSaveImageTextErrorMessage = "Ваш отель был сохранен, но была проблема с загрузкой изображения!";
    public static readonly string HotelPageLoadTextErrorMessage = "Возникла проблема при загрузке отеля!";
    public static readonly string GetHotelByIdTextErrorMessage = "Отель не может быть найден.";
    public static readonly string GetHotelAllTextErrorMessage = "Отели не могут быть найдены.";
    public static readonly string GetHotelAllLoadTextErrorMessage = "Были проблемы с загрузкой данных по отелям.";
    public static readonly string GetHotelImageTextErrorMessage = "Фото отеля не найдено.";

    public static readonly string RoomPageLoadTextErrorMessage = "Возникла проблема при загрузке номера отеля!";
    public static readonly string RoomPageSaveTextErrorMessage = "Возникла проблема с сохранением номера отеля!";
    public static readonly string AddRoomPageSaveImageTextErrorMessage = "Ваш номер отеля был сохранен, но была проблема с загрузкой изображения!";
    public static readonly string GetRoomByIdTextErrorMessage = "Номер отеля не может быть найден.";
    public static readonly string GetRoomImageTextErrorMessage = "Фото номера отеля не найдено.";
  }
}
