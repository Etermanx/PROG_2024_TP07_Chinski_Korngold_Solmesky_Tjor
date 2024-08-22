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
            string sql = "SELECT * FROM Preguntas WHERE (@dificultad = -1 OR IdDificultad = @dificultad) AND (@categoria = -1 OR IdCategoria = @categoria";
            _ListadoPreguntas = BD.Query<Pregunta>(sql, new {dificultad, categoria} ).ToList();
        }

        return _ListadoPreguntas;

    }

    public static List<Respuesta> _ListadoRespuestas = new List<Respuesta>();

    public static List<Respuesta> ObtenerRespuestas(List<Pregunta> preguntas)
    {
        using(SqlConnection BD = new SqlConnection(CONNECTION_STRING))
        {
            

        }


    }


    




}