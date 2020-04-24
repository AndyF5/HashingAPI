using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HashingAPI.Models
{
    public class HashValidationRequest : Hash
    {
        public string StringToValidate { get; set; }

        public HashValidationRequest() : base()
        {
        }

        public HashValidationRequest(string salt, int iterations, string hashedString, string stringToValidate) : base(salt, iterations, hashedString)
        {
            StringToValidate = stringToValidate;
        }
    }
}
