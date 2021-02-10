using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rest.models;
using Rest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private IpersonService _personService;

        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger, IpersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Create(person));
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            person = _personService.FindById(person.Id);
            if (person == null) return NotFound(new { ID = "This ID was not found in our database" });
            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound(new { ID = "This ID was not found in our database" });
            _personService.Delete(id);
            return NoContent();
        }
    }
}
