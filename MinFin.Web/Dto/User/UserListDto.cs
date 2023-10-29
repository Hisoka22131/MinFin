using MinFin.Web.Dto.Base;

namespace MinFin.Web.Dto.User;

public class UserListDto : EntityListDto
{
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string Surname { get; set; } = null!;
}