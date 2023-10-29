using System.ComponentModel;

namespace MinFin.DB.Enums;

public enum PassportType : byte
{
    [Description("ПМР/СССР")]
    Domestic,
    
    [Description("Загран")]
    InternationalPassport
}