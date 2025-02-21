using Microsoft.AspNetCore.Mvc;
using Mission6_Connors.Models;

namespace Mission6_Connors.Controllers;

public class HomeController : Controller
{
    private readonly MovieAdditionContext _context;

    // ✅ Add a constructor to initialize `_context`
    public HomeController(MovieAdditionContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult AddMovie()
    {
        ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
        return View();
    }

    [HttpPost]
    public IActionResult AddMovie(Movie response)
    {
        _context.Movies.Add(response);
        _context.SaveChanges();

        return View("Confirmation", response);
    }

    public IActionResult Confirmation(Movie response)
    {
        return View(response);
    }

    public IActionResult GetToKnowJoel()
    {
        return View("GetToKnow");
    }
}