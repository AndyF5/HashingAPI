using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HashingAPI.Models
{
    public class Hash
    {
        public string Salt { get; set; }
        public int Iterations { get; set; }
        public string HashedString { get; set; }

        public Hash()
        {
        }

        public Hash(string salt, int iterations, string hashedString)
        {
            Salt = salt;
            Iterations = iterations;
            HashedString = hashedString;
        }
    }
}
