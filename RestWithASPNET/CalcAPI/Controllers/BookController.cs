using CalcAPI.Business;
using CalcAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CalcAPI.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookBusiness _bookBusiness;
        public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness)
        {
            _logger = logger;
            _bookBusiness = bookBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Ok(_bookBusiness.FindById(id));
        } 

        [HttpPost]
        public IActionResult Post([FromBody] Book item)
        {
            if (item == null) return BadRequest();
            return Ok(_bookBusiness.Create(item));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book item)
        {
            if(item == null) return BadRequest();
            return Ok(_bookBusiness.Update(item));
        }
    }
}
