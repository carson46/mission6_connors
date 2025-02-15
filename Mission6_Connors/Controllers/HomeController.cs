using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6_Connors.Models;

namespace Mission6_Connors.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(); // Returns the home page
    }

    [HttpGet]
    public IActionResult AddMovie()
    {
        return View(); // Displays the movie entry form
    }

    [HttpPost]
    public IActionResult AddMovie(Movie response)
    {
        return View("Confirmation", response); // Sends form data to Confirmation page
    }

    public IActionResult Confirmation(Movie response)
    {
        return View(response); // Displays confirmation page with movie details
    }

    public IActionResult GetToKnowJoel()
    {
        return View("GetToKnow"); // Displays "Get to Know Joel" page
    }
}