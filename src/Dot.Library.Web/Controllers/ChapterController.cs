using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dot.Library.Database.Model;

namespace Dot.Library.Web.Controllers
{
    public class ChapterController : Controller
    {
        readonly LibraryContext _libraryContext;

        public ChapterController(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        [HttpGet]
        public IEnumerable<Chapter> GetAll() => _libraryContext.Set<Chapter>();

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _libraryContext.Chapter.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult AddChapter([FromBody]Chapter chapter)
        {
            if (chapter == null)
            {
                return BadRequest();
            }
            _libraryContext.Chapter.Add(chapter);
            _libraryContext.SaveChanges();
            return CreatedAtRoute("GetById", new { id = chapter.Id }, chapter);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Chapter chapter)
        {
            if (chapter == null || chapter.Id != id)
            {
                return BadRequest();
            }
            var searchedChapter = _libraryContext.Chapter.FirstOrDefault(x => x.Id == chapter.Id);
            if (searchedChapter == null)
            {
                return NotFound();
            }

            _libraryContext.Entry(searchedChapter).CurrentValues.SetValues(chapter);
            _libraryContext.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var searchedChapter = new Chapter() { Id = id };
            _libraryContext.Chapter.Attach(searchedChapter);
            _libraryContext.Chapter.Remove(searchedChapter);
            _libraryContext.SaveChanges();

            return new NoContentResult();
        }
    }
}
