using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace HashingAPI.Models
{
    public class Hasher
    {
        public Hash GenerateHash(string stringToHash, int iterations = 1000)
        {
            //  Generate salt.
            var salt = new byte[24];
            new RNGCryptoServiceProvider().GetBytes(salt);

            //  Generate hash.
            var pbkdf2 = new Rfc2898DeriveBytes(stringToHash, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(24);

            //  Return concatenation : salt|iterations|hash.
            return new Hash(Convert.ToBase64String(salt), iterations, Convert.ToBase64String(hash));
        }

        public Hash GenerateHash(HashRequest hashRequest)
        {
            int iterations = hashRequest.Iterations == null ? 1000 : hashRequest.Iterations.Value;

            //  Generate salt.
            var salt = new byte[24];
            new RNGCryptoServiceProvider().GetBytes(salt);

            //  Generate hash.
            var pbkdf2 = new Rfc2898DeriveBytes(hashRequest.StringToHash, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(24);

            //  Return concatenation : salt|iterations|hash.
            return new Hash(Convert.ToBase64String(salt), iterations, Convert.ToBase64String(hash));
        }

        private string Generate(string testString, byte[] salt, int iterations)
        {
            //  Generate hash.
            var pbkdf2 = new Rfc2898DeriveBytes(testString, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(24);

            return Convert.ToBase64String(hash);
        }

        public bool IsMatched(string testString, Hash hash)
        {
            byte[] salt = Convert.FromBase64String(hash.Salt);

            string hashedTestPassword = Generate(testString, salt, hash.Iterations);

            return hashedTestPassword == hash.HashedString;
        }
    }
}
