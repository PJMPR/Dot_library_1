using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dot.Library.Database.Model;

namespace Dot.Library.Web.Controllers
{
    [Route("api/[controller]")]
    public class BookReservationController : Controller
    {
        readonly LibraryContext _libraryContext;

        public BookReservationController(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        [HttpGet]
        public IEnumerable<BookReservation> GetAll() => _libraryContext.Set<BookReservation>();

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _libraryContext.BookReservation.FirstOrDefault(x => x.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult AddBookReservation([FromBody]BookReservation bookReservation)
        {
            if (bookReservation == null)
            {
                return BadRequest();
            }
            _libraryContext.BookReservation.Add(bookReservation);
            _libraryContext.SaveChanges();
            return CreatedAtRoute("GetById", new { id = bookReservation.ID }, bookReservation);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]BookReservation bookReservation)
        {
            if (bookReservation == null || bookReservation.ID != id)
            {
                return BadRequest();
            }
            var searchedBookReservation = _libraryContext.BookReservation.FirstOrDefault(x => x.ID == bookReservation.ID);
            if (searchedBookReservation == null)
            {
                return NotFound();
            }
            _libraryContext.Entry(searchedBookReservation).CurrentValues.SetValues(bookReservation);
            _libraryContext.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var searchedBookReservation = new BookReservation() { ID = id };

            _libraryContext.BookReservation.Attach(searchedBookReservation);
            _libraryContext.BookReservation.Remove(searchedBookReservation);
            _libraryContext.SaveChanges();

            return new NoContentResult();
        }
    }
}