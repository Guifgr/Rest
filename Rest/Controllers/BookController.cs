﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rest.Business;
using Rest.models;
using RestWithASPNETUdemy.Hypermedia.Filters;

namespace Rest.Controllers
{
    [ApiVersion("1")]
    [ApiController]
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
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetBooks()
        {
            return Ok(_bookBusiness.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return Ok(_bookBusiness.Create(book));
        }
        
        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] Book book)
        {
            book = _bookBusiness.Update(book);
            if (book == null) return NotFound();
            return Ok(_bookBusiness.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var book = _bookBusiness.FindById(id);
            if (book == null) return NotFound(new { ID = "This ID was not found in our database" });
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}