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

        private static List<Book> _books = new List<Book>() { new Book() {
           ID= 1,
           ImgURL ="http://ecsmedia.pl/c/wiedzmin-tom-7-pani-jeziora-w-iext44045082.jpg",
           Title= "Pani jeziora",Publisher="SuperNowa",Authors= new string[] {"Andrzej Sapkowski"},
           Description = "Potwór zaatakował z " +
            "ciemności, z zasadzki, cicho i wrednie." +
            " Zmaterializował się nagle wśród mroku jak wybuchający płomień. Jak jęzor płomienia",
            Quantity= 666
        }, new Book(){
           ID= 2,
           ImgURL ="http://s.lubimyczytac.pl/upload/books/3937000/3937616/523293-352x500.jpg",
           Title= "Gra o tron",Publisher="SuperNowa",
            Authors = new string[] {"George R.R Martin"},
           Description = "W Zachodnich Krainach o ośmiu tysiącach lat zapisanej historii widmo wojen i katastrofy nieustannie wisi nad ludźmi.",
            Quantity= 667
            }
        };

        private IList<BookReservation> _bookReservations = new List<BookReservation>
        {
            new BookReservation()
            {
                ID = 0,
                reservatedBooks = _books,
                user = new User()
                {
                    adress = "Zadupna 1",
                    login = "420blazeIt",

                };
            }
        };

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
        public IActionResult Put(int id, [FromBody]Book book)
        {
            if (book == null || book.ID != id)
            {
                return BadRequest();
            }
            var searchedBook = _bookReservations.FirstOrDefault(x => x.ID == book.ID);
            if (searchedBook == null)
            {
                return NotFound();
            }
            _bookReservations.Remove(searchedBook);

            ///Dodać mapper gdy bedzie implementacja modelu Book
            ///

            searchedBook.ImgURL = book.ImgURL;
            searchedBook.Publisher = book.Publisher;
            searchedBook.Quantity = book.Quantity;
            searchedBook.Title = book.Title;
            searchedBook.Description = book.Description;
            searchedBook.Authors = book.Authors;
            _bookReservations.Add(searchedBook);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var searchedBook = _bookReservations.FirstOrDefault(x => x.ID == id);
            if (searchedBook == null)
            {
                return NotFound();
            }
            _bookReservations.Remove(searchedBook);
            return new NoContentResult();
        }
    }
}