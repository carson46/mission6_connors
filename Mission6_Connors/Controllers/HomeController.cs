using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6_Connors.Models;
using Microsoft.EntityFrameworkCore;

namespace Mission6_Connors.Controllers;

public class HomeController : Controller
{
    private readonly MovieAdditionContext _context;

    public HomeController(MovieAdditionContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(); // Returns the home page
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
        Console.WriteLine($"Attempting to add movie: {response.Title}, {response.Year}, {response.Director}, {response.CategoryId}, {response.CopiedToPlex}");

        if (!ModelState.IsValid)
        {
            Console.WriteLine("Model validation failed.");
            ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View(response); // Return the form with validation errors
        }

        _context.Movies.Add(response);
        _context.SaveChanges();

        Console.WriteLine("Movie successfully added.");
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
    
    public IActionResult AllMovies()
    {
        var movies = _context.Movies.ToList();
        return View(movies);
    }

    // ✅ Edit Movie (GET)
    [HttpGet]
    public IActionResult EditMovie(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie == null)
        {
            return NotFound();
        }

        ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
        return View(movie);
    }

    // ✅ Edit Movie (POST)
    [HttpPost]
    public IActionResult EditMovie(Movie movie)
    {
        _context.Update(movie);
        _context.SaveChanges();
        return RedirectToAction("AllMovies");
    }

    // ✅ Delete Movie (GET)
    [HttpGet]
    public IActionResult DeleteMovie(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }

    [HttpPost]
    public IActionResult DeleteMovieConfirmed(int id)
    {
        Console.WriteLine($"Attempting to delete movie with ID: {id}"); // Debugging Log

        var movie = _context.Movies.Find(id);
        if (movie != null)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            Console.WriteLine($"Successfully deleted movie with ID: {id}"); // Debugging Log
        }
        else
        {
            Console.WriteLine($"Movie with ID {id} not found."); // Debugging Log
        }

        return RedirectToAction("AllMovies");
    }

}
