using System.Data.Common;
using System.Data.SqlClient;
using Dapper;

public static class BD
{
    const string CONNECTION_STRING = @"Server=localhost;Database=PreguntadOrt;Trusted_Connection=True;";

    private static List<Categoria> _ListadoCategorias = new List<Categoria>();
    public static List<Categoria> ObtenerCategorias()
    {
       using (SqlConnection BD = new SqlConnection(CONNECTION_STRING))
        {
            string sql = "SELECT * FROM Categorias";
            _ListadoCategorias = BD.Query<Categoria>(sql).ToList();
            
        }

        return _ListadoCategorias;


    }   




}