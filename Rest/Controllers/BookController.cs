using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rest.Business;
using Rest.Data.VO;
using Rest.models;
using RestWithASPNETUdemy.Hypermedia.Filters;

namespace Rest.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {
        private readonly IBookBusiness _bookBusiness;
        
        private readonly ILogger<PersonController> _logger;

        public BookController(ILogger<PersonController> logger, IBookBusiness bookBusiness)
        {
            _logger = logger;
            _bookBusiness = bookBusiness;
        }
        
        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<BookVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]        
        [ProducesResponseType(500)]        
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetBooks()
        {
            return Ok(_bookBusiness.FindAll());
        }
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(BookVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]    
        [ProducesResponseType(500)]   
        [TypeFilter(typeof(HyperMediaFilter))]

        public IActionResult GetById(long id)
        {
            var book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType((201), Type = typeof(BookVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]   
        [ProducesResponseType(500)]   
        [TypeFilter(typeof(HyperMediaFilter))]

        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return Ok(_bookBusiness.Create(book));
        }
        
        [HttpPut]
        [ProducesResponseType((200), Type = typeof(BookVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]     
        [ProducesResponseType(500)]   
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] Book book)
        {
            book = _bookBusiness.Update(book);
            if (book == null) return NotFound();
            return Ok(_bookBusiness.Update(book));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]       
        [ProducesResponseType(500)]   
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(long id)
        {
            var book = _bookBusiness.FindById(id);
            if (book == null) return NotFound(new { ID = "This ID was not found in our database" });
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}