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
    public class ChapterController : Controller
    {
        readonly LibraryContext _libraryContext;

        public ChapterController(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        [HttpGet]
        public IEnumerable<ChapterDataContract> GetAll() => _libraryContext.Set<Chapter>().Select(x=> Mapper.Map<ChapterDataContract>(x));

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _libraryContext.Chapter.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(Mapper.Map<ChapterDataContract>(item));
        }

        // POST api/values
        [HttpPost]
        public IActionResult AddChapter([FromBody]ChapterDataContract chapter)
        {
            if (chapter == null)
            {
                return BadRequest();
            }
            var mapped = Mapper.Map<Chapter>(chapter);
            _libraryContext.Chapter.Add(mapped);
            _libraryContext.SaveChanges();
            return CreatedAtRoute("GetById", new { id = mapped.Id }, mapped);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ChapterDataContract chapter)
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

            var mapped = Mapper.Map<Chapter>(chapter);
            _libraryContext.Entry(searchedChapter).CurrentValues.SetValues(mapped);
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
