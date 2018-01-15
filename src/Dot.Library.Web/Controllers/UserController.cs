using Dot.Library.Database.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dot.Library.Web.DataContracts;
using AutoMapper;

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
        public IEnumerable<UserDataContract> GetAll() => _libraryContext.Set<User>().Select(user => Mapper.Map<UserDataContract>(user));

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _libraryContext.User.FirstOrDefault(x => x.id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(Mapper.Map<UserDataContract>(item));
        }

        // POST api/values
        [HttpPost]
        public IActionResult AddUser([FromBody]UserDataContract user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            var mapped = Mapper.Map<User>(user);
            _libraryContext.User.Add(mapped);
            _libraryContext.SaveChanges();
            return CreatedAtRoute("GetById", new { id = mapped.id }, mapped);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]BookDataContract user)
        {
            if (user == null || user.ID != id)
            {
                return BadRequest();
            }
            var searchedUser = _libraryContext.User.FirstOrDefault(x => x.id == user.ID);
            if (searchedUser == null)
            {
                return NotFound();
            }

            var mapped = Mapper.Map<User>(user);

            searchedUser.adress = mapped.adress;
            searchedUser.id = mapped.id;
            searchedUser.login = mapped.login;
            searchedUser.name = mapped.name;
            searchedUser.pass = mapped.pass;
            searchedUser.postalCode = mapped.postalCode;
            searchedUser.surname = mapped.surname;
            _libraryContext.Entry(searchedUser).CurrentValues.SetValues(mapped);
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