using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dot.Library.Database.Model;
using Dot.Library.Database.Model.Dot.Library.Database.Model;

namespace Dot.Library.Web.Controllers
{

    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        readonly LibraryContext _libraryContext;

        public MessageController(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        [HttpGet]
        public IEnumerable<Message> GetAll() => _libraryContext.Set<Message>();

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _libraryContext.Message.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult AddMessage([FromBody]Message message)
        {
            if (message == null)
            {
                return BadRequest();
            }
            _libraryContext.Message.Add(message);
            _libraryContext.SaveChanges();
            return CreatedAtRoute("GetById", new { id = message.Id }, message);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Message message)
        {
            if (message == null || message.Id != id)
            {
                return BadRequest();
            }
            var searchedMessage = _libraryContext.Message.FirstOrDefault(x => x.Id == message.Id);
            if (searchedMessage == null)
            {
                return NotFound();
            }
            _libraryContext.Entry(searchedMessage).CurrentValues.SetValues(message);
            _libraryContext.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var searchedMessage = new Message() { Id = id };
            _libraryContext.Message.Attach(searchedMessage);
            _libraryContext.Message.Remove(searchedMessage);
            _libraryContext.SaveChanges();

            return new NoContentResult();
        }
    }
}