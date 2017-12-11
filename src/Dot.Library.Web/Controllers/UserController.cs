[Route("api/[controller]")]
public class UserController : Controller
{
    private IList<User> _users = new List<User>()
        { new User() {

            id = 1,
            name = "Anna",
            surname = "Nowak",
            login = "smoczyca",
            pass = "ostrekly1",
            adress = "Dêbowa 82, Dawne Lasy",
            postalCode = "10-000"

        },
            new User(){

            id = 2,
            name = "Jan",
            surname = "Kowalski",
            login = "bogacz",
            pass = "money",
            adress = "Diamentowa 154, Bogaty Dwór",
            postalCode = "12-999"
        }
        };

    [HttpGet]
    public IEnumerable<User> GetAll() => _users;


    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var item = _users.FirstOrDefault(x => x.Id == id);
        if (item == null)
        {
            return NotFound();
        }
        return new ObjectResult(item);
    }

    [HttpPost]
    public IActionResult AddUser([FromBody]User user)
    {
        if (user == null)
        {
            return BadRequest();
        }
        _users.Add(user);
        return CreatedAtRoute("GetById", new { id = user.Id }, user);
    }


    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody]User user)
    {
        if (user == null || user.Id != id)
        {
            return BadRequest();
        }
        var searchedUser = _users.FirstOrDefault(x => x.Id == user.Id);
        if (searchedUser == null)
        {
            return NotFound();
        }
        _books.Remove(searchedBook);



        searchedUser.Name = user.Name;
        searchedUser.Surname = user.Surname;
        searchedUser.Login = user.Login;
        searchedUser.Pass = user.Pass;
        searchedUser.Adress = user.Adress;
        searchedUser.PostalCode = user.PostalCode;
        _users.Add(searchedUser);
        return new NoContentResult();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var searchedUser = _users.FirstOrDefault(x => x.Id == id);
        if (searchedUser == null)
        {
            return NotFound();
        }
        _users.Remove(searchedUser);
        return new NoContentResult();
    }
}