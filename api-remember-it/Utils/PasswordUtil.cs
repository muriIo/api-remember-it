using System.Security.Cryptography;
using System.Text;

namespace api_remember_it.Utils
{
    public class PasswordUtil
    {
        public static void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = Convert.ToHexString(hmac.Key);
                passwordHash = Convert.ToHexString(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }

        public static bool VerifyPasswordHash(string password, string passwordHash, string passwordSalt)
        {
            byte[] passwordSaltByte = Convert.FromHexString(passwordSalt);
            byte[] passwordHashByte = Convert.FromHexString(passwordHash);
            using (var hmac = new HMACSHA512(passwordSaltByte))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHashByte);
            }
        }
    }
}
