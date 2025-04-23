namespace Domain.Models
{
  /*
  Сайт https://www.nbrb.by/apihelp/exrates
  Примеры использования:

    полный перечень валют: https://api.nbrb.by/exrates/currencies
    российский рубль: https://api.nbrb.by/exrates/currencies/456
  */

  /// <summary> Справочник валют. Данные будут получены из НБ РБ </summary>
  public class Currency : BaseEntity
  {
    /// <summary> внутренний код </summary>
    public int Cur_ID { get; set; }
    /// <summary>этот код используется для связи, при изменениях наименования, количества единиц к которому устанавливается курс белорусского рубля, буквенного, цифрового кодов и т.д.фактически одной и той же валюты* </summary>
    public Nullable<int> Cur_ParentID { get; set; }
    /// <summary>цифровой код </summary>
    public string Cur_Code { get; set; } = string.Empty;
    /// <summary>буквенный код </summary>
    public string Cur_Abbreviation { get; set; } = string.Empty;
    /// <summary>наименование валюты на русском языке </summary>
    public string Cur_Name { get; set; } = string.Empty;
    /// <summary>наименование на белорусском языке </summary>
    public string Cur_Name_Bel { get; set; } = string.Empty;
    /// <summary>наименование на английском языке </summary>
    public string Cur_Name_Eng { get; set; } = string.Empty;
    /// <summary>наименование валюты на русском языке, содержащее количество единиц </summary>
    public string Cur_QuotName { get; set; } = string.Empty;
    /// <summary>наименование на белорусском языке, содержащее количество единиц </summary>
    public string Cur_QuotName_Bel { get; set; } = string.Empty;
    /// <summary>наименование на английском языке, содержащее количество единиц </summary>
    public string Cur_QuotName_Eng { get; set; } = string.Empty;
    /// <summary>наименование валюты на русском языке во множественном числе </summary>
    public string Cur_NameMulti { get; set; } = string.Empty;
    /// <summary>наименование валюты на белорусском языке во множественном числе* </summary>
    public string Cur_Name_BelMulti { get; set; } = string.Empty;
    /// <summary>наименование на английском языке во множественном числе* </summary>
    public string Cur_Name_EngMulti { get; set; } = string.Empty;
    /// <summary>количество единиц иностранной валюты </summary>
    public int Cur_Scale { get; set; }
    /// <summary>периодичность установления курса(0 – ежедневно, 1 – ежемесячно) </summary>
    public int Cur_Periodicity { get; set; }
    /// <summary>дата включения валюты в перечень валют, к которым устанавливается официальный курс бел.рубля </summary>
    public System.DateTime Cur_DateStart { get; set; }
    /// <summary>дата исключения валюты из перечня валют, к которым устанавливается официальный курс бел.рубля </summary>
    public System.DateTime Cur_DateEnd { get; set; }

    public IEnumerable<Price> Prices { get; set; }
  }
}
