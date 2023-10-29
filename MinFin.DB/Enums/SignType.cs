using System.ComponentModel;

namespace MinFin.DB.Enums;

public enum SignType: byte
{
    [Description("Резидент")]
    Resident,
    
    [Description("Нерзидент")]
    NotResident
}