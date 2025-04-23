using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
  // Сайт https://www.nbrb.by/apihelp/exrates
  // Адрес запроса: https://api.nbrb.by/exrates/rates[/{cur_id}]

 /// <summary> Класс курсов валют по отношению к белорусскому рублю /// </summary>
  public class Rate
  {
    /// <summary> внутренний код </summary>
    [Key]
    public int Cur_ID { get; set; }
    /// <summary> Курс валюты на дату </summary>
    public DateTime Date { get; set; }
    /// <summary>буквенный код </summary>
    public string Cur_Abbreviation { get; set; } = string.Empty;
    /// <summary>количество единиц иностранной валюты </summary>
    public int Cur_Scale { get; set; }
    /// <summary>наименование валюты на русском языке </summary>
    public string Cur_Name { get; set; } = string.Empty;
    /// <summary> Официальный курс </summary>
    public decimal? Cur_OfficialRate { get; set; }
  }
}
