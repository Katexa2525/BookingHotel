using Application.ConstMessages;
using Application.DTO.Hotel;
using Application.DTO.Hotel.ClientRequest;
using Application.DTO.Hotel.CQRS;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.Diagnostics;

namespace BookingHotel.Server.Endpoint.Hotel
{
  /// <summary> Класс конечной точки для загрузки картинки по отелю </summary>
  public class UploadHotelImageEndpoint : BaseAsyncEndpoint.WithRequest<Guid>.WithResponse<string>
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UploadHotelImageEndpoint(IMediator mediator, IMapper mapper)
    {
      _mediator = mediator;
      _mapper = mapper;
    }

    [HttpPost(UploadHotelImageRequest.RouteTemplate)]
    //[HttpPost("/api/hotels/v3/{hotelId}/images")]
    public override async Task<ActionResult<string>> HandleAsync([FromRoute] Guid hotelId, CancellationToken cancellationToken = default)
    {
      // получаю отель по Id
      HotelDto? hotel = await _mediator.Send(new GetByIdHotelQuery() { Id = hotelId });
      if (hotel is null)
      {
        return BadRequest(AppMessage.GetHotelByIdTextErrorMessage);
      }

      //Используя объект Request, пытаюсь загрузить файл, размещенный в запросе, и возвращаю сообщение "Фото не найдено", если файл не найден
      IFormFile? file = Request.Form.Files[0];
      if (file.Length == 0)
      {
        return BadRequest(AppMessage.GetHotelImageTextErrorMessage);
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
      // Проверяет, есть ли у отеля, которому принадлежит изображение, уже существующее изображение
      if (!string.IsNullOrWhiteSpace(hotel.MainPhoto))
      {
        // Если изображение есть, удаляем его из файловой системы
        System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images", hotel.MainPhoto));
      }

      //Обновляю отель, указав местоположение фото отеля. Оно будет использоваться в интерфейсе для загрузки изображения
      hotel.MainPhoto = filename;
      await _mediator.Send(new UpdateHotelCommand() { Dto = _mapper.Map<HotelUpdateDto>(hotel) });

      return Ok(hotel.MainPhoto);

    }
  }
}
