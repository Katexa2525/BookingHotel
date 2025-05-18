using Microsoft.AspNetCore.Components.Forms;

namespace BookingHotel.Validation
{
  public class BootstrapCssClassProvider : FieldCssClassProvider
  {
    public override string GetFieldCssClass(EditContext editContext, in FieldIdentifier fieldIdentifier)
    {
      //Проверяем, есть ли в текущем поле какие-либо ошибки валидации, и сохраняем результат в переменной isValid

      var isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();

      if (editContext.IsModified(fieldIdentifier))
      {
        //Поле было изменено. Возвращаем собственные классы CSS в зависимости от того, является поле корректным или нет
        return isValid ? "is-valid" : "is-invalid";
      }
      else
      {
        //Поле не было изменено. Возвращаем собственный класс CSS, если поле не является корректным
        return isValid ? "" : "is-invalid";
      }
    }
  }
}
