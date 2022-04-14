using CalcAPI.Business;
using CalcAPI.Data.VO;
using CalcAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CalcAPI.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personService;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personService = personBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            try
            {
               var newPerson = _personService.Create(person);
               return Ok(newPerson);
            }
            catch (Exception)
            {
                return BadRequest("ID not allowed");
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
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
