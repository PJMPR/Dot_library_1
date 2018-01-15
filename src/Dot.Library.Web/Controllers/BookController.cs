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
        readonly LibraryContext _libraryContext;  

        public BookController(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        [HttpGet]
        public IEnumerable<BookDataContract> GetAll() => _libraryContext.Set<Book>().Select(book => Mapper.Map<BookDataContract>(book));

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _libraryContext.Book.FirstOrDefault(x => x.ID == id);
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
            _libraryContext.Book.Add(mapped);
            _libraryContext.SaveChanges();
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
            var searchedBook = _libraryContext.Book.FirstOrDefault(x => x.ID == book.ID);
            if (searchedBook == null)
            {
                return NotFound();
            }

            ///Dodać mapper gdy bedzie implementacja modelu Book
            ///

            var mapped = Mapper.Map<Book>(book);
            _libraryContext.Entry(searchedBook).CurrentValues.SetValues(mapped);
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