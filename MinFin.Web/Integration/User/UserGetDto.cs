namespace MinFin.Web.Integration.User;

public class UserGetDto
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;
    
    public string Surname { get; set; } = null!;
}