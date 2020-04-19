using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HashingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HashingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashController : ControllerBase
    {
        private Hasher hasher = new Hasher();

        // GET: api/Hash/string
        [HttpGet("{stringToHash}")]
        public Hash Get(string stringToHash)
        {
            return hasher.GenerateHash(stringToHash);
        }

        // POST: api/Hash
        [HttpPost]
        public IActionResult Post([FromBody] HashRequest hashRequest)
        {
            return Ok(hasher.GenerateHash(hashRequest));
        }
    }
}