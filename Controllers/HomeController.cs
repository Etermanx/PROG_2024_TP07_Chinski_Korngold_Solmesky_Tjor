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
    public IActionResult Creditos()
    {
        return View();
    }
    public IActionResult HighScores()
    {
        ViewBag.HighScores = BD.ObtenerHighScores();
        return View();
    }

    public IActionResult ConfigurarJuego()
    {
        Juego.InicializarJuego();
        ViewBag.Categorias = BD.ObtenerCategorias();
        ViewBag.Dificultades = BD.ObtenerDificultades();
        return View();
    }

    public IActionResult Comenzar(string username, int dificultad, int categoria, string jugarConVidas)
    {
        bool verdaderoJugarConVidas = jugarConVidas != String.Empty && jugarConVidas == "on";

        if (username != String.Empty && (dificultad > 0 || dificultad == -1) && (categoria > 0 || categoria == -1))
        {
            Juego.CargarPartida(username, dificultad, categoria, verdaderoJugarConVidas);
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
        List<Categoria> categorias = BD.ObtenerCategorias();
        Pregunta? proximaPregunta;
        int posProximaCategoria;

        if (Juego.ComprobarHayPartida())
        {
            proximaPregunta = Juego.ObtenerProximaPregunta();

            if (proximaPregunta != null && !Juego.ComprobarPerdido())
            {
                ViewBag.ProximaPregunta = proximaPregunta;
                posProximaCategoria = Juego.BuscarCategoriaLista(ViewBag.ProximaPregunta.IdCategoria, categorias);

                if (Juego.ComprobarCategoriaEsTodo())
                {
                    ViewBag.PosProximaCategoria = posProximaCategoria;
                    ViewBag.Categorias = categorias;
                }
                
                ViewBag.ProximaCategoria = categorias[posProximaCategoria];
                ViewBag.ColorCategoria = Juego.CambiarColorSiDefault(ViewBag.ProximaCategoria.Color);
                
                ViewBag.ProximasRespuestas = Juego.ObtenerProximasRespuestas(ViewBag.ProximaPregunta.IdPregunta);

                if (Juego.ComprobarJugarConVidas())
                {
                    ViewBag.TotalVidas = Juego.ObtenerTotalVidas();
                    ViewBag.ActualVidas = Juego.ObtenerActualVidas();
                }

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
        int posProximaCategoria;
        Pregunta? proximaPregunta;
        List<Categoria> categorias;

        if (Juego.ComprobarHayPartida())
        {
            perdido = Juego.ComprobarPerdido();
            proximaPregunta = Juego.ObtenerPreguntaLista(idPregunta);

            if (idPregunta > 0 && idRespuesta > 0 && proximaPregunta != null)
            {
                categorias = BD.ObtenerCategorias();
                posProximaCategoria = Juego.BuscarCategoriaLista(proximaPregunta.IdCategoria, categorias);
                ViewBag.ProximaCategoria = categorias[posProximaCategoria];
                ViewBag.ColorCategoria = Juego.CambiarColorSiDefault(ViewBag.ProximaCategoria.Color);

                ViewBag.ProximaPregunta = proximaPregunta;
                ViewBag.ProximasRespuestas = Juego.ObtenerProximasRespuestas(ViewBag.ProximaPregunta.IdPregunta);
                ViewBag.RespuestaReal = Juego.ObtenerRespuestaCorrecta(idPregunta);
                ViewBag.IdRespuestaDada = idRespuesta;

                ViewBag.Correcta = Juego.VerificarRespuesta(idPregunta, idRespuesta);
                ViewBag.PuntajeActual = Juego.ObtenerPuntajeActual();

                if (Juego.ComprobarJugarConVidas())
                {
                    if (!ViewBag.Correcta)
                        Juego.BajarActualVidas();

                    ViewBag.TotalVidas = Juego.ObtenerTotalVidas();
                    ViewBag.ActualVidas = Juego.ObtenerActualVidas();

                    if (ViewBag.ActualVidas <= 0)
                        return RedirectToAction("Fin");
                }

                return View("Respuesta");
            }
            else if (perdido)
                return RedirectToAction("Fin");
            else
                return RedirectToAction("Jugar");
        }
        else
            return RedirectToAction("ConfigurarJuego");
    }

    public IActionResult Fin()
    {
        if (Juego.ComprobarHayPartida())
        {
            ViewBag.Perdido = Juego.ComprobarPerdido();
            ViewBag.Username = Juego.ObtenerUsername();
            ViewBag.PuntajeActual = Juego.ObtenerPuntajeActual();
            BD.SubirHighScore(ViewBag.Username, ViewBag.PuntajeActual);
            Juego.DescrearPartida();
            return View();
        }
        else
            return RedirectToAction("ConfigurarJuego");
    }

    public IActionResult BajarActualVidas()
    {
        Juego.BajarActualVidas();
        return Content("", "text/plain");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
