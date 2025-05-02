using Application.DTO.Hotel;
using Application.DTO.Hotel.ClientRequest;
using Application.DTO.Hotel.CQRS;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace BookingHotel.Server.Endpoint.Hotel
{
  /// <summary> Класс конечной точки для загрузки картинки по отелю </summary>
  public class UploadHotelImageEndpoint : BaseAsyncEndpoint.WithRequest<Guid>.WithResponse<string>
  {
    private readonly IMediator _mediator;

    public UploadHotelImageEndpoint(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost(UploadHotelImageRequest.RouteTemplate)]
    public override async Task<ActionResult<string>> HandleAsync([FromRoute] Guid hotelId, CancellationToken cancellationToken = default)
    {
      // получаю отель по Id
      HotelDto? hotel = await _mediator.Send(new GetByIdHotelQuery() { Id = hotelId });
      if (hotel is null)
      {
        return BadRequest("Отель не существует");
      }

      //Используя объект Request, пытаюсь загрузить файл, размещенный в запросе, и возвращаю сообщение "Фото не найдено", если файл не найден
      IFormFile? file = Request.Form.Files[0];
      if (file.Length == 0)
      {
        return BadRequest("Фото отеля не найдено.");
      }

      //Создаю новое имя файла для загруженного изображения, безопасное для использования в приложении
      string? filename = $"{Guid.NewGuid()}.jpg";
      //Определяю место сохранения файла
      string? saveLocation = Path.Combine(Directory.GetCurrentDirectory(), "Images", filename);

      //Используя ImageSharp,изменяю размер загруженного изображения, чтобы получить нужные размеры, и сохраняем его в файловой системе
      var resizeOptions = new ResizeOptions
      {
        Mode = ResizeMode.Pad,
        Size = new Size(640, 426)
      };
      using var image = Image.Load(file.OpenReadStream());
      image.Mutate(x => x.Resize(resizeOptions));
      await image.SaveAsJpegAsync(saveLocation, cancellationToken: cancellationToken);

      //Обновляю тропу, указав местоположение изображения тропы. Оно будет использоваться в интерфейсе для загрузки изображения
      hotel.MainPhoto = filename;
      await _mediator.Send(new UpdateHotelCommand() 
      { 
        Dto = new HotelUpdateDto
        {
          Id = hotel.Id,
          Name = hotel.Name,
          Description = hotel.Description,
          Location = hotel.Location,
          Rating = hotel.Rating,
          Star = hotel.Star,
          MainPhoto = hotel.MainPhoto,
          Rooms = hotel.Rooms,
          Foods = hotel.Foods,
          HotelFacilities = hotel.HotelFacilities,
          HotelPhotos = hotel.HotelPhotos,
          Locations = hotel.Locations,
          Prices = hotel.Prices,
          HotelUsefulInfo = hotel.HotelUsefulInfo
        }
      });

      return Ok(hotel.MainPhoto);

      //throw new NotImplementedException();
    }
  }
}
