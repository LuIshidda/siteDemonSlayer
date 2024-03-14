using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemonSlayer.Models;
using System.Text.Json;

namespace DemonSlayer.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Manga> mangas =[];
        using (StreamReader leitor = new("Data\\mangas.json"))
        {
            string dados = leitor.ReadToEnd();
            mangas = JsonSerializer.Deserialize<List<Manga>>(dados);
        }
        return View(mangas);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
