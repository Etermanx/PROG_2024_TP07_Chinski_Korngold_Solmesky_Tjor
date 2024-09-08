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

    public static List<Pregunta> ObtenerPreguntas(int dificultad, int categoria)
    {
        string sql = "SELECT * FROM Preguntas WHERE (@dificultad = -1 OR IdDificultad = @dificultad) AND (@categoria = -1 OR IdCategoria = @categoria)";
        List<Pregunta> listadoPreguntas = new List<Pregunta>();

        using(SqlConnection BD = new SqlConnection(CONNECTION_STRING))
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

    public static int[] ExtraerIdPreguntas(List<Pregunta> preguntas)
    {
        int cantPreguntas = preguntas.Count;
        int[] idPreguntas = new int[cantPreguntas];

        for (int i = 0; i < cantPreguntas; i++)
            idPreguntas[i] = preguntas[i].IdPregunta;

        return idPreguntas;
    }

    public static bool EsCorrecta(int idRespuesta){
        bool Correcta=false;
        using(SqlConnection db = new SqlConnection(CONNECTION_STRING)){
            string sql= "Select Correcta from Respuestas where IdRespuesta=@pIdRespuesta";
            Correcta = db.QueryFirstOrDefault<bool>(sql, new{pIdRespuesta=idRespuesta});
        }
        return Correcta;
    }

    public static Respuesta? RespuestaCorrecta(int idPregunta){

        Respuesta? respuestaCorrecta;
        using(SqlConnection db = new SqlConnection(CONNECTION_STRING)){
            string sql= "SELECT TOP(1) * FROM Respuestas WHERE IdPregunta = @pIdPregunta AND Correcta = 1";
            respuestaCorrecta = db.QueryFirstOrDefault<Respuesta>(sql, new{ pIdPregunta = idPregunta });
        }
        return respuestaCorrecta;

    }
}