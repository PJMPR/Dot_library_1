using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dot.Library.Database.Model;
using Dot.Library.Web.DataContracts;

using AutoMapper;

namespace Dot.Library.Web.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private IList<Book> _books = new List<Book>();
          

        [HttpGet]
        public IEnumerable<BookDataContract> GetAll() => _books.Select(book => Mapper.Map<BookDataContract>(book));

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _books.FirstOrDefault(x => x.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(Mapper.Map<BookDataContract>(item));
        }

        // POST api/values
        [HttpPost]
        public IActionResult AddBook([FromBody]BookDataContract book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            var mapped = Mapper.Map<Book>(book);
            _books.Add(mapped);
            return CreatedAtRoute("GetById", new { id = mapped.ID }, mapped);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]BookDataContract book)
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

            var mapped = Mapper.Map<Book>(book);

            searchedBook.ImgURL = mapped.ImgURL;
            searchedBook.Publisher = mapped.Publisher;
            searchedBook.Quantity = mapped.Quantity;
            searchedBook.Title = mapped.Title;
            searchedBook.Description = mapped.Description;
            searchedBook.Authors = mapped.Authors;
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