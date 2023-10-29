using MinFin.DB.Enums;
using MinFin.Repository.Models.Base;

namespace MinFin.DB.Domain.Base;

public class PersonalInfoBase : EntityBase
{
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string Surname { get; set; } = null!;
    public string PassportNumber { get; set; } = null!;
    public string PassportSeries { get; set; } = null!;
    public PassportType PassportType { get; set; }
    public SignType SignType { get; set; }
}