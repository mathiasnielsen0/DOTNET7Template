namespace Core.Models.Password;

public class PasswordSaltPair
{
    public PasswordSaltPair(byte[] hashedPassword, byte[] salt)
    {
        HashedPassword = hashedPassword;
        Salt = salt;
    }

    public byte[] HashedPassword { get; set; }
    public byte[] Salt { get; set; }
}