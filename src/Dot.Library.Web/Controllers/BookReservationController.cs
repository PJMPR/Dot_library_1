using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dot.Library.Database.Model;
using AutoMapper;
using Dot.Library.Web.DataContracts;

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
        public IEnumerable<BookReservationDataContract> GetAll() => _libraryContext.Set<BookReservation>().Select(x=> Mapper.Map<BookReservationDataContract>(x));

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _libraryContext.BookReservation.FirstOrDefault(x => x.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(Mapper.Map<BookReservationDataContract>(item));
        }

        // POST api/values
        [HttpPost]
        public IActionResult AddBookReservation([FromBody]BookReservationDataContract bookReservation)
        {
            if (bookReservation == null)
            {
                return BadRequest();
            }
            var mapped = Mapper.Map<BookReservation>(bookReservation);

            _libraryContext.BookReservation.Add(mapped);
            _libraryContext.SaveChanges();
            return CreatedAtRoute("GetById", new { id = mapped.ID }, mapped);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]BookReservationDataContract bookReservation)
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
            var mapped = Mapper.Map<BookReservation>(bookReservation);
       
            _libraryContext.Entry(searchedBookReservation).CurrentValues.SetValues(mapped);
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