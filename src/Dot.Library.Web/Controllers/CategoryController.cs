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
    public class CategoryController : Controller
    {
        readonly LibraryContext _libraryContext;

        public CategoryController(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        [HttpGet]
        public IEnumerable<CategoryDataContract> GetAll() => _libraryContext.Set<Category>().Select(category => Mapper.Map<CategoryDataContract>(category));

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _libraryContext.Category.FirstOrDefault(x => x.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(Mapper.Map<CategoryDataContract>(item));
        }

        // POST api/values
        [HttpPost]
        public IActionResult AdCategory([FromBody]CategoryDataContract category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            var mapped = Mapper.Map<Category>(category);
            _libraryContext.Category.Add(mapped);
            _libraryContext.SaveChanges();
            return CreatedAtRoute("GetById", new { id = mapped.ID }, mapped);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CategoryDataContract category)
        {
            if (category == null || category.ID != id)
            {
                return BadRequest();
            }
            var searchedCategory = _libraryContext.Category.FirstOrDefault(x => x.ID == category.ID);
            if (searchedCategory == null)
            {
                return NotFound();
            }

            var mapped = Mapper.Map<Category>(category);
            _libraryContext.Entry(searchedCategory).CurrentValues.SetValues(mapped);
            _libraryContext.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var searchedCategory = new Category() { ID = id };

            _libraryContext.Category.Attach(searchedCategory);
            _libraryContext.Category.Remove(searchedCategory);
            _libraryContext.SaveChanges();

            return new NoContentResult();
        }
    }
}