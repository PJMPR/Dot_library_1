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

        private static List<BookReservation> _bookReservations = new List<BookReservation>();

        [HttpGet]
        public IEnumerable<BookReservation> GetAll() => _bookReservations;

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _bookReservations.FirstOrDefault(x => x.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult AddBookReservation([FromBody]BookReservation br)
        {
            if (br == null)
            {
                return BadRequest();
            }
            _bookReservations.Add(br);
            return CreatedAtRoute("GetById", new { id = br.ID }, br);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BookReservation br)
        {
            if (br == null || br.ID != id)
            {
                return BadRequest();
            }
            var searchedBookReservation = _bookReservations.FirstOrDefault(x => x.ID == br.ID);
            if (searchedBookReservation == null)
            {
                return NotFound();
            }
            _bookReservations.Remove(searchedBookReservation);

            searchedBookReservation = mapBookReservation(br);

            _bookReservations.Add(searchedBookReservation);

            return new NoContentResult();
        }

        private BookReservation mapBookReservation(BookReservation br)
        {
            return new BookReservation()
            {
                ID = br.ID,
                reservatedBooks = br.reservatedBooks,
                user = br.user
            };
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var searchedBookReservation = _bookReservations.FirstOrDefault(x => x.ID == id);
            if (searchedBookReservation == null)
            {
                return NotFound();
            }
            _bookReservations.Remove(searchedBookReservation);
            return new NoContentResult();
        }
    }
}