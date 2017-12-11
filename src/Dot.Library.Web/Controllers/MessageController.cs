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
        private IList<Message> _messages = new List<Message>(){
            new Message() {
                Id = 0,
                Title = "tytuł 1",
                Content = "zupa 1",
                Target = new User() {
                    name = "Guziec",
                    surname = "Lobuziec"
                },
                SentTime = DateTime.Now.AddDays(-1)
            },
            new Message() {
                Id = 1,
                Title = "tytuł 2",
                Content = "zupa 2",
                Target = new User() {
                    name = "Guziec",
                    surname = "Lobuziec"
                },
                SentTime = DateTime.Now.AddDays(-2)
            }
        };

        [HttpGet]
        public IEnumerable<Message> GetAll() => _messages;

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _messages.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

    }

}