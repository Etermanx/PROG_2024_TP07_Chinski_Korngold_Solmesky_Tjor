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
    public static string ExtraerColorCategoria(int idCategoria, List<Categoria> categorias)
    {
        Categoria? categoria = categorias.Find(categoria => categoria.IdCategoria == idCategoria);
        string color;

        if (categoria != null && categoria.Color != null)
            color = categoria.Color;
        else
            color = "d5d5d5";

        return color;
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

    private static int[] ExtraerIdPreguntas(List<Pregunta> preguntas)
    {
        int cantPreguntas = preguntas.Count;
        int[] idPreguntas = new int[cantPreguntas];

        for (int i = 0; i < cantPreguntas; i++)
            idPreguntas[i] = preguntas[i].IdPregunta;

        return idPreguntas;
    }
}