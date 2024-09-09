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
    public IActionResult PoliticaPrivacidad()
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
            if (Juego.ComprobarHayPreguntas())
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
        if (Juego.ComprobarHayPartida())
        {
            ViewBag.ProximaPregunta = Juego.ObtenerProximaPregunta();

            if (ViewBag.ProximaPregunta != null || Juego.ComprobarPerdido())
            {
                if (Juego.ComprobarCategoriaEsTodo())
                {
                    ViewBag.Categorias = BD.ObtenerCategorias();
                    ViewBag.PosProximaCategoria = Juego.BuscarCategoriaLista(ViewBag.ProximaPregunta.IdCategoria, ViewBag.Categorias);
                    ViewBag.ProximaCategoria = ViewBag.Categorias[ViewBag.PosProximaCategoria];
                }
                ViewBag.ProximasRespuestas = Juego.ObtenerProximasRespuestas(ViewBag.ProximaPregunta.IdPregunta);
                return View("Jugar");
            }
            else
                return RedirectToAction("Fin");
        }
        else
            return RedirectToAction("ConfigurarJuego");
    }

    [HttpPost]
    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        bool perdido;

        if (Juego.ComprobarHayPartida())
        {
            perdido = Juego.ComprobarPerdido();
            ViewBag.ProximaPregunta = Juego.ObtenerPreguntaLista(idPregunta);

            if (idPregunta > 0 && idRespuesta > 0 && !perdido && ViewBag.ProximaPregunta != null)
            {
                ViewBag.ProximasRespuestas = Juego.ObtenerProximasRespuestas(ViewBag.ProximaPregunta.IdPregunta);
                ViewBag.RespuestaReal = Juego.ObtenerRespuestaCorrecta(idPregunta);
                ViewBag.IdRespuestaDada = idRespuesta;
                ViewBag.Correcta = Juego.VerificarRespuesta(idPregunta, idRespuesta);
                ViewBag.PuntajeActual = Juego.ObtenerPuntajeActual();
                return View("Respuesta");
            }
            else if (perdido)
            {
                return RedirectToAction("Fin");
            }
            else
                return RedirectToAction("Jugar");
        }
        else
            return RedirectToAction("ConfigurarJuego");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Respuesta()
    {
        return View();
    }
    public IActionResult Creditos()
    {
        return View();
    }
    public IActionResult CambiarEstadoPerdido()
    {
        Juego.CambiarEstadoPerdido();
        return Content("", "text/plain");
    }
    public IActionResult Fin()
    {
        if (Juego.ComprobarHayPartida())
        {
            ViewBag.Perdido = Juego.ComprobarPerdido();
            ViewBag.Username = Juego.ObtenerUsername();
            ViewBag.PuntajeActual = Juego.ObtenerPuntajeActual();
            return View();
        }
        else
            return RedirectToAction("ConfigurarJuego");
    }

}
