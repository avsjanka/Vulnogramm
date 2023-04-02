using Exsample.Data;
using Exsample.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exsample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    public static IWebHostEnvironment _webHostEnvironment;
    
    public UserController(IWebHostEnvironment environment)
    {
        _webHostEnvironment = environment;
    }

    [HttpPost]
    public string   PostUser(string login, string password)
    {
        Context context = new Context();
        try
        {
            if (login.Length != 0 && password.Length != 0)
            {
                User  new_user = new User {ID = 1,Login = login,Password = password};
                context.User.Add(new_user);
                context.SaveChanges();
                return "Add user";
            }
            else
            {
                return "Not add user";
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}