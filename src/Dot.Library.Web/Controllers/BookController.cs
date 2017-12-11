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
        private IList<Book> _books = new List<Book>();
          

        [HttpGet]
        public IEnumerable<Book> GetAll() => _books;

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _books.FirstOrDefault(x => x.ID == id);
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
            _books.Add(book);
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
            var searchedBook = _books.FirstOrDefault(x => x.ID == book.ID);
            if (searchedBook == null)
            {
                return NotFound();
            }
            _books.Remove(searchedBook);

            ///Dodać mapper gdy bedzie implementacja modelu Book
            ///

            searchedBook.ImgURL = book.ImgURL;
            searchedBook.Publisher = book.Publisher;
            searchedBook.Quantity = book.Quantity;
            searchedBook.Title = book.Title;
            searchedBook.Description = book.Description;
            searchedBook.Authors = book.Authors;
            _books.Add(searchedBook);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var searchedBook = _books.FirstOrDefault(x => x.ID == id);
            if (searchedBook == null)
            {
                return NotFound();
            }
            _books.Remove(searchedBook);
            return new NoContentResult();
        }
    }
}