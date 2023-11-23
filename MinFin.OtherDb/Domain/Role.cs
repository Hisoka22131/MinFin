using MinFin.OtherDb.Domain.Base;

namespace MinFin.OtherDb.Domain;

public class Role : EntityBase
{
    public string Name { get; set; } = null!;
}