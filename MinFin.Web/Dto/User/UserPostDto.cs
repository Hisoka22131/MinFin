using MinFin.Web.Dto.Base;

namespace MinFin.Web.Dto.User;

public class UserPostDto : EntityPostDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string Surname { get; set; } = null!;
    public string PassportNumber { get; set; } = null!;
    public string PassportSeries { get; set; } = null!;
}