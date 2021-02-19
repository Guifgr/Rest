using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rest.models;
using Rest.Business;
using Rest.Data.VO;
using RestWithASPNETUdemy.Hypermedia.Filters;

namespace Rest.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonBusiness _personBusiness;
        
        private readonly ILogger<PersonController> _logger;
        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]        
        [TypeFilter(typeof(HyperMediaFilter))]

        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetById(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        [ProducesResponseType((201), Type = typeof(BookVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]   
        [ProducesResponseType(500)]  
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Create(person));
        }
        
        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(BookVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]     
        [ProducesResponseType(500)]   
        public IActionResult Put([FromBody] PersonVO person)
        {
            person = _personBusiness.Update(person);
            if (person == null) return NotFound();
            return Ok(_personBusiness.Update(person));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]       
        [ProducesResponseType(500)]   
        public IActionResult Delete(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound(new { ID = "This ID was not found in our database" });
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
