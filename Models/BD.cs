using System.Data.Common;
using System.Data.SqlClient;
using Dapper;

public static class BD
{
    const string CONNECTION_STRING = @"Server=localhost;Database=PreguntadOrt;Trusted_Connection=True;";
    
    public static List<Categoria> ObtenerCategorias()
    {   
        using (SqlConnection BD = new SqlConnection(CONNECTION_STRING))
        {   
            string sql = "EXEC SP_ObtenerCategorias";
            return BD.Query<Categoria>(sql).ToList();
        }
    }

    public static List<Dificultad> ObtenerDificultades()
    {
        using (SqlConnection BD = new SqlConnection(CONNECTION_STRING))
        {
            string sql = "EXEC SP_ObtenerDificultades";
            return BD.Query<Dificultad>(sql).ToList();
        }
    }

    public static List<Pregunta> ObtenerPreguntas(int dificultad, int categoria)
    {
        string sql = "EXEC SP_ObtenerPreguntas @dificultad, @categoria";
        List<Pregunta> listadoPreguntas = new List<Pregunta>();

        using (SqlConnection BD = new SqlConnection(CONNECTION_STRING))
        {
            listadoPreguntas = BD.Query<Pregunta>(sql, new {dificultad, categoria} ).ToList();
        }

        return listadoPreguntas;
    }

    public static List<Respuesta> ObtenerRespuestas(List<Pregunta> preguntas)
    {
        string sql = "SELECT * FROM Respuestas WHERE IdPregunta IN @pIdPreguntas;";
        int[] idPreguntas = ExtraerIdPreguntas(preguntas);
        List<Respuesta> listadoRespuestas;
        
        using(SqlConnection BD = new SqlConnection(CONNECTION_STRING))
        {
            listadoRespuestas = BD.Query<Respuesta>(sql, new { pIdPreguntas = idPreguntas }).ToList();
        }

        return listadoRespuestas;
    }

    public static List<HighScore> ObtenerHighScores()
    {
        string sql = "EXEC SP_ObtenerHighScores;";
        List<HighScore> listadoHighScores;
        
        using(SqlConnection BD = new SqlConnection(CONNECTION_STRING))
        {
            listadoHighScores = BD.Query<HighScore>(sql).ToList();
        }

        return listadoHighScores;
    }

    public static void SubirHighScore(string username, int puntaje)
    {
        string sql = "EXEC SP_SubirHighScore @pUsername, @pPuntaje;";
        
        using(SqlConnection BD = new SqlConnection(CONNECTION_STRING))
        {
            BD.Execute(sql, new { pUsername = username, pPuntaje = puntaje });
        }
    }

    private static int[] ExtraerIdPreguntas(List<Pregunta> preguntas)
    {
        int cantPreguntas = preguntas.Count;
        int[] idPreguntas = new int[cantPreguntas];

        for (int i = 0; i < cantPreguntas; i++)
            idPreguntas[i] = preguntas[i].IdPregunta;

        return idPreguntas;
    }
}