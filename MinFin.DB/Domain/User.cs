using MinFin.DB.Domain.Base;

namespace MinFin.DB.Domain;

public class User : PersonalInfoBase
{
    public string Email { get; set; } = null!;

    public byte[] Password { get; set; } = null!;

    public byte[] PasswordKey { get; set; } = null!;
}