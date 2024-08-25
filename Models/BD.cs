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
            string sql = "SELECT * FROM Categorias";
            return BD.Query<Categoria>(sql).ToList();
        }
    }


    
    public static List<Dificultad> ObtenerDificultades()
    {
        using (SqlConnection BD = new SqlConnection(CONNECTION_STRING))
        {
            string sql = "SELECT * FROM Dificultades";
            return BD.Query<Dificultad>(sql).ToList();
        }
    }


    public static List<Pregunta> _ListadoPreguntas = new List<Pregunta>();
    public static List<Pregunta> ObtenerPreguntas(int dificultad, int categoria)
    {
        using(SqlConnection BD = new SqlConnection(CONNECTION_STRING))
        {
            string sql = "SELECT * FROM Preguntas WHERE (@dificultad = -1 OR IdDificultad = @dificultad) AND (@categoria = -1 OR IdCategoria = @categoria)";
            _ListadoPreguntas = BD.Query<Pregunta>(sql, new {dificultad, categoria} ).ToList();
        }

        return _ListadoPreguntas;

    }

    public static List<Respuesta> ObtenerRespuestas(List<Pregunta> preguntas)
    {
        string sql = "SELECT * FROM Respuestas WHERE IdPregunta IN (@pIdPreguntas);";
        string stringIdPreguntas;
        int[] idPreguntas;
        List<Respuesta> listadoRespuestas;

        idPreguntas = ExtraerIdPreguntas(preguntas);
        stringIdPreguntas = string.Join(", ", idPreguntas);
        
        using(SqlConnection BD = new SqlConnection(CONNECTION_STRING))
        {
            listadoRespuestas = BD.Query<Respuesta>(sql, new { pIdPreguntas = stringIdPreguntas }).ToList();
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