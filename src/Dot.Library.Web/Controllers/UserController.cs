using Dot.Library.Database.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dot.Library.Web.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        readonly LibraryContext _libraryContext;

        public UserController(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        [HttpGet]
        public IEnumerable<User> GetAll() => _libraryContext.Set<User>();

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _libraryContext.User.FirstOrDefault(x => x.id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult AddUser([FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            _libraryContext.User.Add(user);
            _libraryContext.SaveChanges();
            return CreatedAtRoute("GetById", new { id = user.id }, user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]User user)
        {
            if (user == null || user.id != id)
            {
                return BadRequest();
            }
            var searchedUser = _libraryContext.User.FirstOrDefault(x => x.id == user.id);
            if (searchedUser == null)
            {
                return NotFound();
            }


            _libraryContext.Entry(searchedUser).CurrentValues.SetValues(user);
            _libraryContext.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var searchedUser = new User() { id = id };
            _libraryContext.User.Attach(searchedUser);
            _libraryContext.User.Remove(searchedUser);
            _libraryContext.SaveChanges();

            return new NoContentResult();
        }

    }
}