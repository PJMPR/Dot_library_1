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


        //private readonly IUserRepository _userRepository;

        //public UserController(IUserRepository userRepository)
        //{
        //    _userRepository = userRepository;
        //}

        //public IEnumerable<User> Get()
        //{
        //    return _userRepository.Get();
        //}

        //public User Get(int id)
        //{
        //    var user = _userRepository.Get(id);

        //    if (user == null)
        //    {
        //        throw new HttpResponseException(new HttpResponseMessage
        //        {
        //            StatusCode = HttpStatusCode.NotFound,
        //            Content = new StringContent("User not found")
        //        });
        //    }

        //    return task;
        //}

        //public HttpResponseMessage<User> Post(User user)
        //{
        //    user = _userRepository.Post(user);

        //    var response = new HttpResponseMessage<User>(user, HttpStatusCode.Created);

        //    string uri = Url.Route(null, new { id = user.Id });
        //    response.Headers.Location = new Uri(Request.RequestUri, uri);

        //    return response;
        //}

        //public User Put(User user)
        //{
        //    try
        //    {
        //        user = _userRepository.Put(user);
        //    }
        //    catch (Exception)
        //    {
        //        throw new HttpResponseException(new HttpResponseMessage
        //        {
        //            StatusCode = HttpStatusCode.NotFound,
        //            Content = new StringContent("Task not found")
        //        });
        //    }

        //    return user;
        //}

        //public HttpResponseMessage Delete(int id)
        //{
        //    _userRepository.Delete(id);

        //    return new HttpResponseMessage
        //    {
        //        StatusCode = HttpStatusCode.NoContent
        //    };
        //}



    }
}