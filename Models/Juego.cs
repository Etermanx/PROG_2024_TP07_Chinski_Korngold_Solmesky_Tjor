public static class Juego
{
    const int SUMA_PUNTAJE = 500;
    public static string username { get; private set; }
    public static int puntajeActual { get; private set; }
    public static int cantidadPreguntasCorrectas { get; private set; }
    public static List<Pregunta> preguntas { get; private set; }
    private static List<Respuesta> respuestas { get; set; }
    private static int posCorrecta { get; set; }

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

    public static void CargarPartida(string nuevoUsername, int dificultad, int categoria)
    {
        username = nuevoUsername; // Preguntar para que el username
        preguntas = BD.ObtenerPreguntas(dificultad, categoria);
        respuestas = BD.ObtenerRespuestas(preguntas);
    }

    public static Pregunta? ObtenerProximaPregunta()
    {
        int valorRandom;
        Random rnd;
        Pregunta? proximaPregunta = null;

        if (preguntas.Count > 0)
        {
            rnd = new Random();
            valorRandom = rnd.Next(0, preguntas.Count);
            proximaPregunta = preguntas[valorRandom];
        }

        // cambiar bd para q las preguntas puedan ser nulas(sin cant)
        // |-> huh?
        
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

    public static bool VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        int posCorrecta = BuscarRespuestaCorrecta(idPregunta);
        bool correcta = posCorrecta != -1 && idRespuesta == posCorrecta;

        if (correcta)
        {
            puntajeActual += SUMA_PUNTAJE;
            cantidadPreguntasCorrectas++;
            preguntas.RemoveAt(BuscarPregunta(idPregunta));
        }

        return correcta;
    }
    public static Respuesta? MostrarRespuestaCorrecta()
    {
        Respuesta? respuestaCorrecta = null;
        if (posCorrecta != -1)
            respuestaCorrecta = respuestas[posCorrecta];
        return respuestaCorrecta;
    }

    private static int BuscarPregunta(int idPregunta)
    {
        int posPregunta = preguntas.Count - 1;
        while (posPregunta >= 0 && idPregunta != preguntas[posPregunta].IdPregunta)
            posPregunta--;
        return posPregunta;
    }
    private static int BuscarRespuestaCorrecta(int idPregunta)
    {
        int posRespuesta = respuestas.Count - 1;
        while (posRespuesta >= 0 && idPregunta != respuestas[posRespuesta].IdPregunta && !respuestas[posRespuesta].Correcta)
            posRespuesta--;
        return posRespuesta;
    }
}