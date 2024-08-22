public class Juego
{
    private static string username { get; set; }
    private static int puntajeActual { get; set; }
    private static int cantidadPreguntasCorrectas { get; set; }
    private static List<Pregunta> preguntas { get; set; }
    private static List<Respuesta> respuestas { get; set; }

    public static void InicializarJuego(){

        username = string.Empty;
        puntajeActual = 0;
        cantidadPreguntasCorrectas = 0;
        preguntas.Clear();
        respuestas.Clear();
    }

    public static List<Categoria> ObtenerCategorias(){

        return BD.ObtenerCategorias();
    }

    public static List<Dificultad> ObtenerDificultades(){

        return BD.ObtenerDificultades();
    }

    public static void CargarPartida(string username, int dificultad, int categoria){

//Preguntar para que el username

        preguntas = BD.ObtenerPreguntas(dificultad, categoria);
        respuestas = BD.ObtenerRespuestas(preguntas);


    }

    public static Pregunta ObtenerProximaPregunta(){

        if  (preguntas.Count() > 0){

            Random rnd = new Random();
            int valor_random = rnd.Next(preguntas.Count);
            return preguntas[valor_random];
        }
        
        // cambiar bd para q las preguntas puedan ser nulas(sin cant)
        return null;
    
    }
//falta Obtenerproximasrespuestas y verificarrespuesta


}