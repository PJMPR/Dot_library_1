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
        private IList<Book> _books = new List<Book>() { new Book() {
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
           Title= "Gra o tron",Publisher="SuperNowa",Authors= new string[] {"George R.R Martin"},
           Description = "W Zachodnich Krainach o ośmiu tysiącach lat zapisanej historii widmo wojen i katastrofy nieustannie wisi nad ludźmi.",
            Quantity= 667} };

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