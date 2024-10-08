public static class Juego
{
    const int SUMA_PUNTAJE = 500;
    const int TOTAL_VIDAS = 3;
    private static string? username { get; set; }
    private static int puntajeActual { get; set; }
    private static int cantidadPreguntasCorrectas { get; set; }
    private static int actualVidas { get; set; }
    private static List<Pregunta> preguntas { get; set; }
    private static List<Respuesta> respuestas { get; set; }
    private static bool categoriaEsTodo { get; set; }
    private static bool jugarConVidas { get; set; }
    private static bool perdido { get; set; }


    public static void InicializarJuego()
    {
        username = string.Empty;
        puntajeActual = 0;
        cantidadPreguntasCorrectas = 0;
        preguntas = new List<Pregunta>();
        respuestas = new List<Respuesta>();
    }

    public static List<Categoria> ObtenerCategorias()
    {
        return BD.ObtenerCategorias();
    }

    public static List<Dificultad> ObtenerDificultades()
    {
        return BD.ObtenerDificultades();
    }

    public static void CargarPartida(string elUsername, int dificultad, int categoria, bool elJugarConVidas)
    {
        categoriaEsTodo = categoria == -1;
        username = elUsername;
        preguntas = BD.ObtenerPreguntas(dificultad, categoria);
        respuestas = BD.ObtenerRespuestas(preguntas);
        jugarConVidas = elJugarConVidas;

        if (jugarConVidas)
            actualVidas = TOTAL_VIDAS;
        else
            actualVidas = 1;
    }

    public static bool ComprobarHayPartida()
    {
        return username != null;
    }
    public static void DescrearPartida()
    {
        username = null;
    }
    public static bool ComprobarHayPreguntas()
    {
        return preguntas != null && preguntas.Count() > 0;
    }
    public static bool ComprobarCategoriaEsTodo()
    {
        return categoriaEsTodo;
    }
    public static bool ComprobarPerdido()
    {
        return actualVidas == 0;
    }
    public static bool ComprobarJugarConVidas()
    {
        return jugarConVidas;
    }

    public static string? ObtenerUsername()
    {
        return username;
    }
    public static int ObtenerTotalVidas()
    {
        return TOTAL_VIDAS;
    }
    public static int ObtenerActualVidas()
    {
        return actualVidas;
    }
    public static void BajarActualVidas()
    {
        actualVidas--;
    }

    public static Pregunta? ObtenerProximaPregunta()
    {
        int valorRandom;
        Random rnd;
        Pregunta? proximaPregunta = null;

        if (ComprobarHayPreguntas())
        {
            rnd = new Random();
            valorRandom = rnd.Next(0, preguntas.Count);
            proximaPregunta = preguntas[valorRandom];
        }
        
        return proximaPregunta;
    }
    public static List<Respuesta> ObtenerProximasRespuestas(int idPregunta)
    {
        List<Respuesta> proximasRespuestas = new List<Respuesta>();
        foreach (Respuesta respuesta in respuestas)
            if (respuesta.IdPregunta == idPregunta)
                proximasRespuestas.Add(respuesta);
        return proximasRespuestas;
        
    }

    public static Pregunta? ObtenerPreguntaLista(int idPregunta)
    {
        int posPregunta = BuscarPregunta(idPregunta);
        Pregunta? pregunta = null;

        if (posPregunta != -1)
            pregunta = preguntas[posPregunta];

        return pregunta;
    }
    public static bool VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        int posRespuesta = BuscarRespuesta(idRespuesta);
        bool correcta = posRespuesta != -1 && respuestas[posRespuesta].Correcta;

        if (correcta)
        {
            puntajeActual += SUMA_PUNTAJE;
            cantidadPreguntasCorrectas++;
        }

        preguntas.RemoveAt(BuscarPregunta(idPregunta));
        return correcta;
    }
    public static Respuesta? ObtenerRespuestaCorrecta(int idPregunta)
    {
        int posRespuesta = BuscarRespuestaCorrecta(idPregunta);
        Respuesta? respuestaCorrecta = null;

        if (posRespuesta != -1)
            respuestaCorrecta = respuestas[posRespuesta];

        return respuestaCorrecta;
    }
    public static int ObtenerPuntajeActual()
    {
        return puntajeActual;
    }


    public static int BuscarCategoriaLista(int idCategoria, List<Categoria> lista)
    {
        int posCategoria = lista.Count - 1;
        while (posCategoria >= 0 && idCategoria != lista[posCategoria].IdCategoria)
            posCategoria--;
        return posCategoria;
    }
    public static string CambiarColorSiDefault(string color)
    {
        if (color == null)
            color = "d5d5d5";
        return color;
    }
    private static int BuscarPregunta(int idPregunta)
    {
        int posPregunta = preguntas.Count - 1;
        while (posPregunta >= 0 && idPregunta != preguntas[posPregunta].IdPregunta)
            posPregunta--;
        return posPregunta;
    }
    private static int BuscarRespuesta(int idRespuesta)
    {
        int posRespuesta = respuestas.Count - 1;
        while (posRespuesta >= 0 && respuestas[posRespuesta].IdRespuesta != idRespuesta)
            posRespuesta--;
        return posRespuesta;
    }
    private static int BuscarRespuestaCorrecta(int idPregunta)
    {
        int posRespuesta = respuestas.Count - 1;
        while (posRespuesta >= 0 && (idPregunta != respuestas[posRespuesta].IdPregunta || !respuestas[posRespuesta].Correcta))
            posRespuesta--;
        return posRespuesta;
    }
}
