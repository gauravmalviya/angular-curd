using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookapi.Data;
using bookapi.Data.Entities;
using bookapi.ServiceContracts;
using bookapi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bookapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        // GET api/Book
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _bookService.GetBooks();
            if (result == null)
                return NotFound(new { result = "NOTFOUND" });
            else
                return Ok(new { result = "SUCCESS", data = result });
        }

        // GET api/Book/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookViewModel>> Get(string id)
        {
            var result = await _bookService.GetBook(id);
            if (result == null)
                return NotFound(new { result = "NOTFOUND"});
            else
                return Ok(new { result = "SUCCESS", data = result });
        }

        // POST api/Book
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookViewModel value)
        {
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            var result = await _bookService.SaveBook(value);
            return Ok(new { result = "SUCCESS", data = result });
        }

        // PUT api/Book/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] BookViewModel inputData)
        {
            var _oBook = await _bookService.GetBook(id);
            if (_oBook == null)
                return NotFound(new { result = "NOTFOUND" });
            else
            {
                inputData.Patch(_oBook);
                await _bookService.UpdateBook(id, _oBook);
                return Ok(new { result = "SUCCESS", data = id });
            }
        }

        // DELETE api/Book/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _bookService.GetBook(id);
            if (result == null)
                return NotFound(new { result = "NOTFOUND" });
            else
            {
                await _bookService.DeleteBook(id);
                return Ok(new { result = "SUCCESS", data = id });
            }
        }
    }
}
