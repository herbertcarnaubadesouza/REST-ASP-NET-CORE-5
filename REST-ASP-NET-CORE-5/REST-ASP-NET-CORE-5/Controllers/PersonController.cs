using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using REST_ASP_NET_CORE_5.Model;
using REST_ASP_NET_CORE_5.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_ASP_NET_CORE_5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonService personService,ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var person = _personService.FindAll();
            return Ok(person);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindByID(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            return Ok(_personService.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            return Ok(_personService.Update(person));
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }


    }
}
