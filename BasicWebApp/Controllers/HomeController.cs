using Microsoft.AspNetCore.Mvc;
using BasicWebApp.Data;
using BasicWebApp.Models;
using System.Linq;

public class HomeController : Controller
{
    private readonly BasicWebAppContext _context;

    public HomeController(BasicWebAppContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = _context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
        if (user != null)
        {
            return RedirectToAction("Hello");
        }

        ViewBag.Message = "Invalid username or password";
        return View();
    }

    [HttpGet]
    public IActionResult ForgotPassword()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ForgotPassword(string username)
    {
        var user = _context.Users.SingleOrDefault(u => u.Username == username);
        if (user != null)
        {
            ViewBag.Message = $"Your password is: {user.Password}";
            return View();
        }

        ViewBag.Message = "Invalid username";
        return View();
    }

    public IActionResult Hello()
    {
        return View();
    }
}
