﻿using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IConvertorService _convertor;

        public PersonController(IConvertorService convertor)
        {
            _convertor = convertor;
        }

        [HttpPost("/addPerson")]
        public async Task<int> Save(string json)
        {
          
            using (var stream = new MemoryStream())
            {
                _convertor.Deserialize(stream, typeof(Person));
            }
            
            
        }

        [HttpGet("/getAllPersons")]
        public async Task<string> GetAll(GetAllRequest request)
        {
           string result;
           using(Stream stream = new MemoryStream())
            {
                 _convertor.Serialize(stream, request);
                result = stream.ToString()??"NoPersonFound";
            }
            return result;
        }



    }
}
