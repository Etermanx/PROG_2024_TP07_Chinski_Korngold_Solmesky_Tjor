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

    public IActionResult ConfigurarJuego()
    {
        Juego.InicializarJuego();
        ViewBag.Categorias = BD.ObtenerCategorias();
        ViewBag.Dificultades = BD.ObtenerDificultades();
        return View();
    }

    public IActionResult Comenzar(string username, int dificultad, int categoria)
    {
        if (username != String.Empty && (dificultad > 0 || dificultad == -1) && (categoria > 0 || categoria == -1))
        {
            Juego.CargarPartida(username, dificultad, categoria);
            if (Juego.preguntas.Count > 0)
                return RedirectToAction("Jugar");
            else
                ViewBag.Error = "Erm... La base de datos no tiene preguntas para esta dificultad/categoria...";
        }
        else
            ViewBag.Error = "¡Debés completar todos los campos!";

        ViewBag.Categorias = BD.ObtenerCategorias();
        ViewBag.Dificultades = BD.ObtenerDificultades();
        return View("ConfigurarJuego");
    }

    public IActionResult Jugar()
    {
        ViewBag.ObtenerPreguntas = Juego.ObtenerProximaPregunta();
        ViewBag.ObtenerIdPreguntas  = ViewBag.ObtenerPreguntas.IdPregunta;

        if(ViewBag.ObtenerPreguntas.Count == 0){
            return View("Fin");
        }
        else{
            ViewBag.ObtenerRespuestas = Juego.ObtenerProximasRespuestas(ViewBag.ObtenerIdPreguntas);
            return View("Juego");
        }
    }

    [HttpPost]
    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        if (idPregunta > 0 && idRespuesta > 0)
        {
            ViewBag.Respuesta = Juego.VerificarRespuesta(idPregunta, idRespuesta);
            ViewBag.Correcta = Juego.MostrarRespuestaCorrecta();
            return View("Respuesta");
        }
        else
            return RedirectToAction("Jugar");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
}
