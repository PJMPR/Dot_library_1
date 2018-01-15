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

    public class AuthorController : Controller
    {

        readonly LibraryContext _libraryContext;

        public AuthorController(LibraryContext libraryContext)  
        {
            _libraryContext = libraryContext;
        }

        [HttpGet]
        public IEnumerable<AuthorDataContract> GetAll() => _libraryContext.Set<Author>().Select(x=> Mapper.Map<AuthorDataContract>(x));

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _libraryContext.Author.FirstOrDefault(x => x.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(Mapper.Map<AuthorDataContract>(item));
        }

        // POST api/values
        [HttpPost]
        public IActionResult AddAuthor([FromBody]AuthorDataContract author)
        {
            if (author == null)
            {
                return BadRequest();
            }
            var mapped = Mapper.Map<Author>(author);
            _libraryContext.Author.Add(mapped);
            _libraryContext.SaveChanges();
            return CreatedAtRoute("GetById", new { id = mapped.ID }, mapped);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]AuthorDataContract author)
        {
            if (author == null || author.ID != id)
            {
                return BadRequest();
            }
            var searchedAuthor = _libraryContext.Author.FirstOrDefault(x => x.ID == author.ID);
            if (searchedAuthor == null)
            {
                return NotFound();
            }

            var mapped = Mapper.Map<Author>(author);
            _libraryContext.Entry(searchedAuthor).CurrentValues.SetValues(mapped);
            _libraryContext.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var searchedAuthor = new Author() { ID = id };
            _libraryContext.Author.Attach(searchedAuthor);
            _libraryContext.Author.Remove(searchedAuthor);
            _libraryContext.SaveChanges();

            return new NoContentResult();
        }
    }

}