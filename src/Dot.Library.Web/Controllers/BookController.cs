using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dot.Library.Database.Model;

namespace Dot.Library.Web.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        readonly LibraryContext _libraryContext;  

        public BookController(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        [HttpGet]
        public IEnumerable<Book> GetAll() => _libraryContext.Set<Book>();

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _libraryContext.Book.FirstOrDefault(x => x.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult AddBook([FromBody]Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            _libraryContext.Book.Add(book);
            _libraryContext.SaveChanges();
            return CreatedAtRoute("GetById", new { id = book.ID }, book);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Book book)
        {
            if (book == null || book.ID != id)
            {
                return BadRequest();
            }
            var searchedBook = _libraryContext.Book.FirstOrDefault(x => x.ID == book.ID);
            if (searchedBook == null)
            {
                return NotFound();
            }
            _libraryContext.Entry(searchedBook).CurrentValues.SetValues(book);
            _libraryContext.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var searchedBook = new Book() { ID = id };

            _libraryContext.Book.Attach(searchedBook);
            _libraryContext.Book.Remove(searchedBook);
            _libraryContext.SaveChanges();

            return new NoContentResult();
        }
    }
}