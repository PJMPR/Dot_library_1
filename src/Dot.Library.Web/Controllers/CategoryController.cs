using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dot.Library.Database.Model;

namespace Dot.Library.Web.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private IList<Category> _category = new List<Category>() { 
        new Category() {
           ID= 1,
           Title= "Przygodowe"}, 
        new Category(){
           ID= 2,
           Title= "Krymina³"}, 
        new Category(){
           ID= 3,
           Title= "Fantasy"},};

        [HttpGet]
        public IEnumerable<Category> GetAll() => _category;

      
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _category.FirstOrDefault(x => x.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody]Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            _category.Add(category);
            return CreatedAtRoute("GetById", new { id = category.ID }, category);
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Category category)
        {
            if (category == null || category.ID != id)
            {
                return BadRequest();
            }
            var searchedCategory = _category.FirstOrDefault(x => x.ID == category.ID);
            if (searchedCategory == null)
            {
                return NotFound();
            }
            _category.Remove(searchedCategory);

          
            searchedCategory.Title = category.Title;
          
            _category.Add(searchedCategory);
            return new NoContentResult();
        }

      
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var searchedCategory = _category.FirstOrDefault(x => x.ID == id);
            if (searchedCategory == null)
            {
                return NotFound();
            }
            _category.Remove(searchedCategory);
            return new NoContentResult();
        }
    }
}