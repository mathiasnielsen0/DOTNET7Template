using Core.Models;

namespace Core.Interfaces
{
    public interface IPasswordUtilities
    {
        byte[] GenerateSalt(Func<double> random);
        PasswordSaltPair CreateHashedPasswordAndSalt(string password);
        bool ValidatePassword(string passwordToValide, byte[] currentHashedPassword, byte[] currentSalt);
        bool ValidatePassword(string passwordToValidate, PasswordSaltPair currentHashedPasswordAndSalt);
    }
}