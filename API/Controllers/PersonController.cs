using API.Models;
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
        public Task<int> Save(string json)
        {
            // deserialize string into object of type Person using own deserializer that can be reused later (see more details in Minimal requirements section)
            // DO NOT use 3rd party libraries for deserialization like Json.NET or Microsoft
            // insert or update Person entity in database
            // return entity id

            _convertor
        }

        [HttpGet("/getAllPersons")]
        public Task<string> GetAll(GetAllRequest request)
        {
            // get Persons entities from database
            // filter by GetAllRequest fields (null or empty fields should be ignored)
            // use your own manually written json serializer to serialize result into string
            throw new NotSupportedException();
        }



    }
}
