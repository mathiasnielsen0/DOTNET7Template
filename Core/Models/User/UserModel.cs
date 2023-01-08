namespace Core.Models.User;

public class UserModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public Guid? ResetPasswordGuid { get; set; }
    public byte[] PasswordHash { get; set; } = null!;
    public byte[] Salt { get; set; } = null!;
    public bool Administrator { get; set; }
}