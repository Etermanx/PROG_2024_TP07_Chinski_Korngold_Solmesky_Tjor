using System.Diagnostics;
using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using PROG_2024_TP07_Chinski_Korngold_Tjor.Models;
using Microsoft.Extensions.Caching.Memory;

namespace PROG_2024_TP07_Chinski_Korngold_Tjor.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }
    // Debe llamar al método  de la clase Juego y retornar la View ConfigurarJuego. Por ViewBag deben viajar las categorías y dificultades!
    public IActionResult ConfigurarJuego()
    {
        Juego.InicializarJuego();
        ViewBag.Categorias = BD.ObtenerCategorias();
        ViewBag.Dificultades = BD.ObtenerDificultades();
        return View();
    }

    public IActionResult Comenzar(string username, int dificultad, int categoria)
    {
        IActionResult action;

        // invoca al método CargarPartida de la clase Juego y, siempre y cuando lleguen preguntas de la base de datos, redirige el sitio al ActionResult Jugar. En caso de elegir una configuración sin preguntas en base de datos, debe redirigir nuevamente al ActionResult ConfigurarJuego.
        if (username == String.Empty && dificultad <= 0 && categoria <= 0)
        {
            Juego.CargarPartida(username, dificultad, categoria);
            if (Juego.preguntas.Count > 0)
                action = RedirectToAction("Jugar");
            else
                ViewBag.Error = "Erm... La base de datos no tiene preguntas para esta dificultad/categoria...";
        }
        else
            ViewBag.Error = "¡Debés completar todos los campos!";

        ViewBag.Categorias = BD.ObtenerCategorias();
        ViewBag.Dificultades = BD.ObtenerDificultades();
        action = View("ConfigurarJuego");

        return action;
    }

    public IActionResult Jugar()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
