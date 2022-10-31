using System.Text;
using Konscious.Security.Cryptography;
using System.Security.Cryptography;

namespace PropertiesOnEarthAPI.Helpers
{
    public class EncryptionHelper
    {
        public bool VerifyHash(string password, string hash, string salt, string pepper)
        {
            var newHash = HashPassword(password, salt, pepper);
            return hash == newHash;
        }
        public string CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return Convert.ToBase64String(buffer);
        }
        public string HashPassword(string password, string salt, string pepper)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

            argon2.Salt = Encoding.UTF8.GetBytes(salt + pepper);
            argon2.DegreeOfParallelism = 8; // four cores
            argon2.Iterations = 4;
            argon2.MemorySize = 1024 * 1024; // 1 GB

            return Convert.ToBase64String(argon2.GetBytes(16));
        }

    }
}