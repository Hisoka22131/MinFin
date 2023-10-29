namespace MinFin.Repository.Models.Base;

public abstract class EntityBase
{
    public int Id { get; set; }
    public DateTime CreateDt { get; set; }
    public DateTime UpdateDt { get; set; }
    public bool IsDeleted { get; set; }
}