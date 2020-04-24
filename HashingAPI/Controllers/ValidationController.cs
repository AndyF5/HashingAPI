using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using HashingAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HashingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationController : ControllerBase
    {
        private Hasher hasher = new Hasher();

        // POST: api/Validation
        [EnableCors]
        [HttpPost]
        public IActionResult Post([FromBody] HashValidationRequest hashValidationRequest)
        {
            //hashValidationRequest.Salt = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(hashValidationRequest.Salt));
            //hashValidationRequest.HashedString = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(hashValidationRequest.HashedString));
            return Ok(hasher.IsMatched(hashValidationRequest.StringToValidate, hashValidationRequest));
        }
    }
}