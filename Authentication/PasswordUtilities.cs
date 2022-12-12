using System.Security.Cryptography;
using Core.Interfaces;
using Core.Models;

namespace Authentication
{
    public class PasswordUtilities : IPasswordUtilities
    {
        public const int SaltLength = 10;
        private const int PasswordLength = 30;

        private byte[] GenerateSalt()
        {
            var random = new Random();
            return GenerateSalt(random.NextDouble);
        }

        public byte[] GenerateSalt(Func<double> random)
        {
            const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            var salt = new char[SaltLength];

            for (var i = 0; i <= SaltLength - 1; i++)
            {
                salt[i] = allowedChars[(int) Math.Floor(allowedChars.Length * random())];
            }

            return salt.Select(Convert.ToByte).ToArray();
        }

        public PasswordSaltPair CreateHashedPasswordAndSalt(string password)
        {
            var salt = GenerateSalt();

            //TODO FIND ANDEN KRYPTERINGSALGORITME
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, 720000))
            {
                var hashedPassword = deriveBytes.GetBytes(PasswordLength);

                return new PasswordSaltPair(hashedPassword, salt);
            }
        }

        public bool ValidatePassword(string passwordToValide, byte[] currentHashedPassword, byte[] currentSalt)
        {
            return ValidatePassword(passwordToValide, new PasswordSaltPair(currentHashedPassword, currentSalt));
        }

        public bool ValidatePassword(string passwordToValidate, PasswordSaltPair currentHashedPasswordAndSalt)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(passwordToValidate, currentHashedPasswordAndSalt.Salt, 720000))
            {
                var hashedPasswordToValidate = deriveBytes.GetBytes(PasswordLength);

                return hashedPasswordToValidate.SequenceEqual(currentHashedPasswordAndSalt.HashedPassword);
            }
        }
    }
}