using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{
    public UserController()
    {

    }

    // Create User Action
    [HttpPost]
    public IActionResult CreateUser(User user)
    {
        UserService.AddUser(user);
        return CreatedAtAction(nameof(CreateUser), new { id = user.Id }, user);
    }

    [HttpGet]

    public ActionResult<List<User>> GetUsers() => UserService.GetUsers();

    [HttpGet("{id}")]

    public ActionResult<User> Get(int id)
    {
        var user = UserService.GetUser(id);

        if(user == null)
            return NotFound();

        return user;
    }

    [HttpPut("{id}")]

    public IActionResult UpdateUser(int id, User user)
    {
        if (id != user.Id)
            return BadRequest();
        
        var existingUser = UserService.GetUser(id);
        if(existingUser is null)
            return NotFound();
    
        UserService.UpdateUser(user);           
    
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        // This code will delete the pizza and return a result
        var user = UserService.GetUser(id);
   
        if (user is null)
            return NotFound();
        
        UserService.DeleteUser(id);
    
        return NoContent();
    }
}