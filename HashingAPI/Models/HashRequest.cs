using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HashingAPI.Models
{
    public class HashRequest
    {
        public string StringToHash { get; set; }
        public int? Iterations { get; set; }
    }
}
