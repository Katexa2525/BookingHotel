﻿namespace Application.ConstMessages
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
    public static readonly string ValidatorRoomHotelIdNumberMessage = "Введите Id отеля";
    public static readonly string ValidatorRoomTypeIdNumberMessage = "Введите тип номера отеля";
    public static readonly string ValidatorRoomIdNumberMessage = "Введите Id номера отеля";

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

    public static readonly string ValidatorBookingNameMessage = "Введите наименование бронирования";
    public static readonly string ValidatorBookingArrivalDateMessage = "Введите дату начала бронирования";
    public static readonly string ValidatorBookingDepartureDateMessage = "Введите дату окончания бронирования";
    public static readonly string GetBookingByIdTextErrorMessage = "Бронирование не может быть найдено.";

    public static readonly string GetFoodByIdTextErrorMessage = "Питание не может быть найдено.";
    public static readonly string ValidatorFoodNameMessage = "Введите наименование питания";
    public static readonly string ValidatorTypeFoodNameMessage = "Введите тип питания";
    public static readonly string ValidatorHotelFoodNameMessage = "Введите отель питания";

    public static readonly string ValidatorGuestNameMessage = "Введите имя гостя";
    public static readonly string ValidatorGuestLastNameMessage = "Введите фамилию гостя";
    public static readonly string ValidatorGuestBookingIdMessage = "Введите документ бронирования гостя";

    public static readonly string ValidatorPriceRoomIdMessage = "Введите номера отеля для цены";
    public static readonly string ValidatorPriceCurrencyIdMessage = "Введите валюту для цены";
    public static readonly string ValidatorPriceDateStartMessage = "Введите дату начала";
    public static readonly string ValidatorPriceDateEndMessage = "Введите дату окончания";
    public static readonly string ValidatorPriceDayPriceMessage = "Введите значение цены";

    public static readonly string ValidatorHotelFacilityNameMessage = "Введите наименование удобства отеля";
    public static readonly string HotelFacilityPageLoadTextErrorMessage = "Возникла проблема при загрузке удобства отеля!";
    public static readonly string HotelFacilityPageSaveTextErrorMessage = "Возникла проблема с сохранением удобств отеля!";
    public static readonly string GetHotelFacilityByIdTextErrorMessage = "Запись по удобству отеля не может быть найдена.";

    public static readonly string ValidatorLocationNameMessage = "Введите наименование близжайшей локации отеля";
    public static readonly string LocationPageSaveTextErrorMessage = "Возникла проблема с сохранением близлежащих локаций отеля!";
    public static readonly string GetLocationByIdTextErrorMessage = "Запись по локациям отеля не может быть найдена.";

    public static readonly string ValidatorRoomFacilityNameMessage = "Введите наименование удобства номера отеля";
    public static readonly string RoomFacilityPageSaveTextErrorMessage = "Возникла проблема с сохранением удобств номера отеля!";

    public static readonly string PricePageSaveTextErrorMessage = "Возникла проблема с сохранением цен номера отеля!";
    public static readonly string GetPriceByIdTextErrorMessage = "Запись по цене номера отеля не может быть найдена.";

    public static readonly string ValidatorRoomPhotoNameMessage = "Введите номера отеля, которому принадлежит фото";
    public static readonly string RoomPhotoPageSaveTextErrorMessage = "Возникла проблема с сохранением фото номера отеля!";
    public static readonly string GetRoomPhotoByIdTextErrorMessage = "Запись по фото номера отеля не может быть найдена.";

    public static readonly string ValidatorReviewHotelIdMessage = "Введите номер отеля для отзыва";
    public static readonly string ValidatorReviewNameMessage = "Введите заголовок отзыва";
    public static readonly string ValidatorReviewDescriptionMessage = "Введите описание отзыва";
    public static readonly string ValidatorReviewStarMessage = "Введите оценку отзыва";
    public static readonly string GetReviewByIdTextErrorMessage = "Запись отзыву отеля не может быть найдена.";
    public static readonly string ReviewPageSaveTextErrorMessage = "Возникла проблема с сохранением отзыва!";
    public static readonly string ReviewPageLoadTextErrorMessage = "Возникла проблема при загрузке отеля!";

    public static readonly string ValidatorHotelPhotoNameMessage = "Введите отель, которому принадлежит фото";
    public static readonly string GetHotelPhotoByIdTextErrorMessage = "Запись по фото отеля не может быть найдена.";
    public static readonly string HotelPhotoPageSaveTextErrorMessage = "Возникла проблема с сохранением фото отеля!";

    public static readonly string GetGuestByIdTextErrorMessage = "Гость из бронирования не может быть найден.";

  }
}
